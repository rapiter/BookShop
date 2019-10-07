using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;

namespace BookShop.Infrastructure.SQLData
{
    public static class DbInitializer
    {
        public static void SeedDB(BookShopAppContext ctx)
        {
            // ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            if (ctx.Books.Any())
            {
                return; // DB has been seeded
            }

            Author a = new Author() { Firstname = "John", Lastname = "Ray", Birthdate = DateTime.Now, Description = "Cool author" };
            Genre g = new Genre() { GenreType = "Drama" };

            List<Book> books = new List<Book>();
            books.Add(new Book() { Title = "Sad story", Genre = g, Price = 199.9, Description = "Very sad story of author." });
            books.Add(new Book() { Title = "Sad story 2", Genre = g, Price = 199.9, Description = "Very sad story of author part 2." });
            books.Add(new Book() { Title = "Sad story 3", Genre = g, Price = 199.9, Description = "Very sad story of author part 3." });

            ctx.Authors.Attach(a).State = EntityState.Added;
            ctx.Genres.Attach(g).State = EntityState.Added;
            ctx.Books.AddRange(books);

            ctx.SaveChanges();
        }
    }
}