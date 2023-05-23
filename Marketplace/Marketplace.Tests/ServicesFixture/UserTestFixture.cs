using AutoMapper;
using Bogus;
using Bogus.Extensions.Brazil;
using Marketplace.Entities.Entities;
using Marketplace.Interfaces.Repositories;
using Marketplace.Services.Services;
using Moq;

namespace Marketplace.Tests.ServicesFixture
{
    public class UserTestFixture : IDisposable
    {
        public UserService userService { get; private set; }
        public UserTestFixture() 
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            Faker<User> _fakerUserResponseDto = new Faker<User>()
                .RuleFor(m => m.IDUser, f => 1)
                .RuleFor(m => m.Name, f => f.Name.FirstName())
                .RuleFor(m => m.Cpf, f => f.Person.Cpf())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.PasswordHash, f => f.Random.String())
                .RuleFor(m => m.Phone, f => f.Person.Phone)
                .RuleFor(m => m.Address, f => f.Person.Address.Street)
                .RuleFor(m => m.City, f => f.Address.City())
                .RuleFor(m => m.State, f => f.Address.City())
                .RuleFor(m => m.Country, f => f.Address.Country())
                .RuleFor(m => m.ZipCode, f => f.Address.ZipCode())
                .RuleFor(m => m.IsSeller, f => false);

            userRepositoryMock.Setup(x => x.GetUserByIdAsync(1)).ReturnsAsync(_fakerUserResponseDto);
            userRepositoryMock.Setup(x => x.GetAllUsers()).ReturnsAsync(_fakerUserResponseDto.Generate(5));

            userService = new UserService(userRepositoryMock.Object);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
