using Microsoft.EntityFrameworkCore.Internal;

namespace BookShop.Infrastructure.SQLData
{
    public class DbInitializer
    {
        public static void SeedDB(BookShopAppContext ctx)
        {
            // ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            if (ctx.Books.Any())
            {
                return; // DB has been seeded
            }
            
            
            
            
            
            
        }
    }
}