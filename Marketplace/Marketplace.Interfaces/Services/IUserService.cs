using Marketplace.Entities.Entities;
using Marketplace.Models.Dto;

namespace Marketplace.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> SaveUser(UserCreateDto user);
        Task<int> UpdateUser(UserUpdateDto user);
        Task DeleteUser(int idUser);
        Task<List<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto> GetUserByIdAsync(int idUser);
        Task<int> UserChangePassword(int idUser, string password);
    }
}
