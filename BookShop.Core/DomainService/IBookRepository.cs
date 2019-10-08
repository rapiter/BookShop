using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.DomainService
{
    public interface IBookRepository
    {
            Book CreateBook(Book book);
            Book Delete(int ID);
            Book Update(Book bookUpdate);
            Book GetBookByID(int id);
            IEnumerable<Book> GetBooks(Filter filter = null);
        
    }
}