using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData
{
    public class BookShopAppContext : DbContext

    {
        
        public BookShopAppContext(DbContextOptions<BookShopAppContext> opt) : base(opt)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
   
          


        }
    }

    
}