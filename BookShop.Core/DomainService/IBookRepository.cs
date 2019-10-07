using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.DomainService
{
    public interface IBookRepository
    {
            Book CreateBook(Book book);
            Book Delete(Book book);
            Book Update(Book bookUpdate);
            Book ReadyById(int id);
            List<Book> GetBooks();
        
    }
}