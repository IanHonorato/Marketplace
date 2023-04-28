using Microsoft.EntityFrameworkCore;

namespace Marketplace.Data.Data
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options) { }
    }
}
