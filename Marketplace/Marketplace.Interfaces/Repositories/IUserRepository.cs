using Marketplace.Models.Dto;
using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task SaveUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int idUser);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByIdAsync(int idUser);
        Task UserChangePassword(int idUser, string password);
    }
}
