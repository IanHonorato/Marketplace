using Marketplace.Services.Services;
using Marketplace.Tests.ServicesTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Tests.ServicesFixture
{
    public class UserTestFixture : IDisposable
    {
        public UserService userService { get; private set; }
        public UserTestFixture() { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
