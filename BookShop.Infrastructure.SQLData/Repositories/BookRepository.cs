using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class BookRepository : IBookRepository
    {

        readonly BookShopAppContext _context;

        public BookRepository(BookShopAppContext ctx)
        {
            _context = ctx;
        }
        
        public Book CreateBook(Book book)
        {
            _context.Attach(book).State = EntityState.Added;
            _context.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
           var bookToRemove = new Book {ID = id};
            _context.Entry(bookToRemove).State = EntityState.Deleted;

            try

            {

                _context.SaveChanges();

            }

            catch (DbUpdateConcurrencyException ex)

            {

                ex.Entries.Single().Reload();

               _context.SaveChanges();

            }
            return bookToRemove;
        }

        public Book Update(Book bookUpdate)
        {
            _context.Attach(bookUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return bookUpdate;
        }

        public Book GetBookByID(int id)
        {
            return _context.Books.FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Book> GetBooks(Filter filter)
        {
            var orderBy = filter.OrderBy;
            var sortBy = filter.SortBy;

            if (filter.ItemsPrPage <= 0 || filter.CurrentPage <= 0) return _context.Books;
            
            if (sortBy != null)
            {
                var propertyInfo = typeof(Book).GetProperty(filter.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if(orderBy == "asc" || orderBy == null)
                {
                    return _context.Books.OrderBy(x => propertyInfo.GetValue(x,
                            null))
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                        .Take(filter.ItemsPrPage);
                }
                if(orderBy == "desc"){
                    return _context.Books.OrderByDescending(x => propertyInfo.GetValue(x,
                            null))
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                        .Take(filter.ItemsPrPage);
                }
            }
            
            if(orderBy == "asc" || orderBy == null)
            {
                return _context.Books.OrderBy(b => b.ID).Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }
            
            if(orderBy == "desc"){
                return _context.Books.OrderByDescending(b => b.ID).Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }

            return _context.Books;
        }
        
    }
}