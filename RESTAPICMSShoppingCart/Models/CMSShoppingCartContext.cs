using Microsoft.EntityFrameworkCore;

namespace RESTAPICMSShoppingCart.Models
{
    public class CMSShoppingCartContext : DbContext
    {
        public CMSShoppingCartContext(DbContextOptions<CMSShoppingCartContext> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
    }
}
