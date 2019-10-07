using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

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
            throw new NotImplementedException();
        }

        public Book Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public Book Update(Book bookUpdate)
        {
            throw new NotImplementedException();
        }

        public Book ReadyById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }
    }
}