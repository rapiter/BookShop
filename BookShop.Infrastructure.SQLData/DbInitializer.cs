﻿using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Infrastructure.SQLData
{
    public static class DbInitializer
    {
        public static void SeedDB(BookShopAppContext ctx)
        {
            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            
            if (ctx.Books.Any())
            {
                return; // DB has been seeded
            }
            
            //Creating Authors
            ctx.Authors.Add(new Author() { Firstname = "John", Lastname = "Ray", Birthdate = DateTime.Now, Description = "Cool author" });
            ctx.Authors.Add(new Author() { Firstname = "John", Lastname = "Ray", Birthdate = DateTime.Now, Description = "Cool author" });
            ctx.Authors.Add(new Author() { Firstname = "John", Lastname = "Ray", Birthdate = DateTime.Now, Description = "Cool author" });


            //Creating Genres
            List<Genre> genres = createGenres();
            ctx.Genres.AddRange(genres);



            List<Book> books = new List<Book>();
            var b = new Book() { Title = "Sad story", Genre = genres.FirstOrDefault(g => g.ID == 13), Price = 199.9, Description = "Very sad story of author." };
            var b2 = new Book() { Title = "Sad story 2", Genre = genres.FirstOrDefault(g => g.ID == 12), Price = 199.9, Description = "Very sad story of author part 2." };
            var b3 = new Book() { Title = "Sad story 3", Genre = genres.FirstOrDefault(g => g.ID == 11), Price = 199.9, Description = "Very sad story of author part 3." };
            books.Add(b);
            books.Add(b2);
            books.Add(b3);

            List<BookAuthor> l = new List<BookAuthor>();
      


            ctx.BookAuthors.AddRange(l);
            ctx.Books.AddRange(books);

            ctx.SaveChanges();
        }

        static List<Genre> createGenres()
        {
            List<Genre> gList = new List<Genre>();
            Genre g = new Genre() { GenreType = "Science Fiction" }; gList.Add(g);
            Genre g2 = new Genre() { GenreType = "Romance" }; gList.Add(g2);
            Genre g3 = new Genre() { GenreType = "Fantasy" }; gList.Add(g3);
            Genre g4 = new Genre() { GenreType = "Crime" }; gList.Add(g4);
            Genre g5 = new Genre() { GenreType = "Horror" }; gList.Add(g5);
            Genre g6 = new Genre() { GenreType = "Comics" }; gList.Add(g6);
            Genre g7 = new Genre() { GenreType = "Comedy" }; gList.Add(g7);
            Genre g8 = new Genre() { GenreType = "Romance" }; gList.Add(g8);
            Genre g9 = new Genre() { GenreType = "Thriller" }; gList.Add(g9);
            Genre g10 = new Genre() { GenreType = "Western" }; gList.Add(g10);
            Genre g11 = new Genre() { GenreType = "Biography" }; gList.Add(g11);
            Genre g12 = new Genre() { GenreType = "Textbook" }; gList.Add(g12);
            Genre g13 = new Genre() { GenreType = "Self-help " }; gList.Add(g13);
            return gList;
        }

    }
}