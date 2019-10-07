using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData
{
    public class BookShopAppContext : DbContext

    {
        
        public BookShopAppContext(DbContextOptions<BookShopAppContext> opt) : base(opt)
        {

        }

    }
}