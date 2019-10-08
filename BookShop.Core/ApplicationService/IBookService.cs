using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService
{
    public interface IBookService
    {
        Book CreateNewBook(String title,
            Genre genre,
            String description,
            String publisher,
            DateTime releaseDate,
            int nrOfPages,
            double price,
            String language,
            Double rating,
            String ageRange);
        
        Book CreateBook(Book book);
        Book Delete(int ID);
        Book Update(Book bookUpdate);
        Book GetBookByID(int id);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetFilteredBooks(Filter filter);

    }
}