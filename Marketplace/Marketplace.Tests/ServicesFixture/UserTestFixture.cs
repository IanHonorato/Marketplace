﻿using Bogus;
using Bogus.Extensions.Brazil;
using Marketplace.Entities.Entities;
using Marketplace.Repository.Repositories;
using Marketplace.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Tests.ServicesFixture
{
    public class UserTestFixture : IDisposable
    {
        public UserService userService { get; private set; }
        public UserTestFixture() 
        {
            var userRepositoryMock = new Mock<UserRepository>();
            Faker<User> _fakerUser = new Faker<User>()
                .RuleFor(m => m.IDUser, f => 1)
                .RuleFor(m => m.Name, f => f.Name.FirstName())
                .RuleFor(m => m.Cpf, f => f.Person.Cpf())
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.PasswordHash, f => f.Random.String())
                .RuleFor(m => m.PasswordSalt, f => f.Random.String())
                .RuleFor(m => m.Phone, f => f.Person.Phone)
                .RuleFor(m => m.Address, f => f.Person.Address.Street)
                .RuleFor(m => m.City, f => f.Address.City())
                .RuleFor(m => m.State, f => f.Address.City())
                .RuleFor(m => m.Country, f => f.Address.Country())
                .RuleFor(m => m.ZipCode, f => f.Address.ZipCode())
                .RuleFor(m => m.IsSeller, f => false)
                .RuleFor(m => m.CreatedAt, f => f.Date.Past())
                .RuleFor(m => m.UpdatedAt, f => f.Date.Past());

            userRepositoryMock.Setup(x => x.GetUserByIdAsync(1)).ReturnsAsync(_fakerUser);

            userService = new UserService(userRepositoryMock.Object);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
