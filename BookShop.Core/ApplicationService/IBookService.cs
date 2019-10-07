using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public interface IBookService
    {
        Book CreateNewBook(String title,
            Genre genre,
            Author author,
            String description,
            String publisher,
            DateTime releaseDate,
            int nrOfPages,
            String language,
            Double rating,
            String ageRange);
        
        Book CreateBook(Book book);
        Book Delete(Book book);
        Book Update(Book bookUpdate);
        Book ReadyById(int id);
        List<Book> GetBooks();
    }
}