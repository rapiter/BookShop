using System;
using System.Collections.Generic;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class BookService : IBookService
    {
        private IBookRepository BookRepository;

        public BookService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }
        
        
        public Book CreateNewBook(string title, Genre genre, string description, string publisher, DateTime releaseDate,
            int nrOfPages,double price, string language, double rating, string ageRange)
        {
            Book b = new Book()
            {
                Title = title,
                Genre = genre,

            };
            return b;
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

        public Book GetBookByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return BookRepository.GetBooks();
        }
    }
}