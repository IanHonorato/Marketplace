using Marketplace.Models.Dto;
using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<int> SaveUser(User user);
        Task<int> UpdateUser(User user);
        Task DeleteUser(int idUser);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByIdAsync(int idUser);
        List<User> GetAllUsersSellers();
        Task<int> UserChangePassword(int idUser, string password);
    }
}
