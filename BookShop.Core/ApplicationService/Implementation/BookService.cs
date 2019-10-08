using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        
        public Book CreateNewBook(string title, Genre genre, string description, string publisher, DateTime releaseDate,
            int nrOfPages,double price, string language, double rating, string ageRange)
        {
            var b = new Book()
            {
                Title = title,
                Genre = genre,
            };
            IsNullOrEmpty.Check(b);
            return _bookRepository.CreateBook(b);
        }

        public Book CreateBook(Book book)
        {
            IsNullOrEmpty.Check(book);
            return _bookRepository.CreateBook(book);
        }

        public Book Delete(int id)
        {
            return _bookRepository.Delete(id) == null ? throw new InvalidDataException("Book not found or already deleted")
                : _bookRepository.Delete(id);
        }

        public Book Update(Book bookUpdate)
        {
            return _bookRepository.Update(bookUpdate);
        }

        public Book GetBookByID(int id)
        {
            return _bookRepository.GetBookByID(id) == null ? throw new InvalidDataException("Book not found")
                : _bookRepository.GetBookByID(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public IEnumerable<Book> GetFilteredBooks(Filter filter)
        {
            return _bookRepository.GetBooks(filter);
        }
    }
}