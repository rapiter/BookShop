using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class BookRepository : IBookRepository
    {

        readonly BookShopAppContext context;

        public BookRepository(BookShopAppContext ctx)
        {
            context = ctx;
        }
        public Book CreateBook(Book book)
        {
            context.Attach(book).State = EntityState.Added;
            context.SaveChanges();
            return book;
        }

        public Book Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
            return null;
        }

        public Book Update(Book bookUpdate)
        {
            context.Attach(bookUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return bookUpdate;
        }

        public Book GetBookByID(int id)
        {
            return context.Books.FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
               //.Include(b => b.Genre.GenreType);
        }
    }
}