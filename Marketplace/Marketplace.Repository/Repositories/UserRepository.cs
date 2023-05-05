using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Models.Dto;

namespace Marketplace.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }
        public Task DeleteUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserResponseDto>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task SaveUser(UserCreateDto user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserUpdateDto user)
        {
            throw new NotImplementedException();
        }

        public Task UserChangePassword(int idUser, string password)
        {
            throw new NotImplementedException();
        }
    }
}
