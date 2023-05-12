using Marketplace.Data.Data;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Models.Dto;
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
            var user = await _context.User.FindAsync(idUser);
            return user;
        }

        public async Task SaveUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public Task UserChangePassword(int idUser, string password)
        {
            throw new NotImplementedException();
        }
    }
}
