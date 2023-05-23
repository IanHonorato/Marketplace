using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;

namespace Marketplace.Services.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }
        public Task DeleteUser(int idUser)
        {
            var request = _userRepository.DeleteUser(idUser);
            return request;
        }

        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var userResponseDtos = new List<UserResponseDto>();
            
            foreach (var user in users)
            {
                userResponseDtos.Add(new UserResponseDto
                {
                    IDUser = user.IDUser,
                    Name = user.Name,
                    Cpf = user.Cpf,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Phone = user.Phone,
                    Address = user.Address,
                    City = user.City,
                    State = user.State,
                    Country = user.Country,
                    ZipCode = user.ZipCode,
                    IsSeller = user.IsSeller
                });
            }
            
            return userResponseDtos;
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int idUser)
        {
            var user = await _userRepository.GetUserByIdAsync(idUser);
            if (user != null)
            {
                var userResponseDto = new UserResponseDto
                {
                    IDUser = user.IDUser,
                    Name = user.Name,
                    Cpf = user.Cpf,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Phone = user.Phone,
                    Address = user.Address,
                    City = user.City,
                    State = user.State,
                    Country = user.Country,
                    ZipCode = user.ZipCode,
                    IsSeller = user.IsSeller
                };
                return userResponseDto;
            }
            return null;
        }

        public async Task<int> SaveUser(UserCreateDto userDto)
        {
            var user = new User(
                userDto.Name, userDto.Cpf, userDto.Email, userDto.PasswordHash, "PasswordSalt", userDto.Phone, userDto.Address, userDto.City, userDto.State,
                userDto.Country, userDto.ZipCode, userDto.IsSeller, DateTime.Now, DateTime.Now);
            var idUser = await _userRepository.SaveUser(user);
            
            return idUser;
        }

        public async Task<int> UpdateUser(UserUpdateDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userDto.IDUser);
            
            if(user != null)
            {
                if(userDto.Name != null) user.Name = userDto.Name;
                if(userDto.Cpf != null) user.Cpf = userDto.Cpf;
                if(userDto.Email != null) user.Email = userDto.Email;
                if(userDto.PasswordHash != null) user.PasswordHash = userDto.PasswordHash;
                if(userDto.Phone != null) user.Phone = userDto.Phone;
                if(userDto.Address != null) user.Address = userDto.Address;
                if(userDto.City != null) user.City = userDto.City;
                if(userDto.State != null) user.State = userDto.State;
                if(userDto.Country != null) user.Country = userDto.Country;
                if(userDto.ZipCode != null) user.ZipCode = userDto.ZipCode;
                user.IsSeller = userDto.IsSeller;
                user.UpdatedAt = DateTime.Now;

                int request = await _userRepository.UpdateUser(user);

                return request;
            }

            return 0;
        }

        public async Task<int> UserChangePassword(int idUser, string password)
        {
            var request = await _userRepository.UserChangePassword(idUser, password);
            return request;
        }
    }
}
