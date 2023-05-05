using Marketplace.Models.Dto;
using Marketplace.Entities.Entities;

namespace Marketplace.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task SaveUser(UserCreateDto user);
        Task UpdateUser(UserUpdateDto user);
        Task DeleteUser(int idUser);
        Task<List<UserResponseDto>> GetAllUsers();
        Task<User> GetUserByIdAsync(int idUser);
        Task UserChangePassword(int idUser, string password);
    }
}
