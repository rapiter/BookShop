using System;
using System.Collections.Generic;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class BookRepository : IBookRepository
    {
      

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

        public List<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}