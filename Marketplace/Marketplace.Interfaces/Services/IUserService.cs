using Marketplace.Entities.Entities;
using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IUserService
    {
        Task SaveUser(UserCreateDto user);
        Task UpdateUser(UserUpdateDto user);
        Task DeleteUser(int idUser);
        Task<List<UserResponseDto>> GetAllUsers();
        Task<User> GetUserByIdAsync(int idUser);
        Task UserChangePassword(int idUser, string password);
    }
}
