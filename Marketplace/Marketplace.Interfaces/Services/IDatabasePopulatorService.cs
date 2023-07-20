using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Interfaces.Services
{
    public interface IDatabasePopulatorService
    {
        Task DatabasePopulator();
    }
}
