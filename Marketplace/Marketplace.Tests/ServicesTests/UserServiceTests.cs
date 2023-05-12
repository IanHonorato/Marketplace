using Marketplace.Tests.ServicesFixture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Tests.ServicesTests
{
    public class UserServiceTests : IClassFixture<UserTestFixture>
    {
        private readonly UserTestFixture _fixture;
        public UserServiceTests(UserTestFixture fixture) {  _fixture = fixture; }

        [Fact]
        public async Task GetByIdAsync_ReturnsUser_WhenUserExists()
        {
            var result = await _fixture.userService.GetUserByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.IDUser);
        }

        [Fact]
        public async void Test_Meet_Performance_Requirements()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = await _fixture.userService.GetAllUsers();
            stopwatch.Stop();

            Assert.True(stopwatch.ElapsedMilliseconds < 1000); //Example performance requirement of less than 1 second
        }
    }
}
