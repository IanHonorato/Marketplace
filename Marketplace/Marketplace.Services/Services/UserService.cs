using Marketplace.Interfaces.Repositories;
using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Task<List<UserResponseDto>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> GetUser(int idUser)
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
