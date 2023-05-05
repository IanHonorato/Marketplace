using Marketplace.Tests.ServicesFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Tests.ServicesTests
{
    public class UserServiceTests : IClassFixture<UserTestFixture>
    {
        private readonly UserTestFixture _fixture;
        public UserServiceTests(UserTestFixture fixture) {  _fixture = fixture; }
    }
}
