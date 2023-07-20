using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketplaceContext _context;
        public UserRepository(MarketplaceContext context) 
        {
            _context = context;
        }
        public async Task DeleteUser(int idUser)
        {
            var user = await _context.User.FindAsync(idUser);
            if(user != null) 
            { 
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int idUser)
        {
            return await _context.User.FindAsync(idUser);
        }

        public List<User> GetAllUsersSellers()
        {
            return _context.User.Where(x => x.IsSeller == true).ToList();
        }

        public async Task<int> SaveUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.IDUser;
        }

        public async Task<int> UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();

            return user.IDUser;
        }

        public async Task<int> UserChangePassword(int idUser, string password)
        {
            var user = await _context.User.FindAsync(idUser);
            if( user != null )
            {
                user.PasswordHash = password;
                await _context.SaveChangesAsync();

                return user.IDUser;
            }

            return 0;
        }
    }
}
