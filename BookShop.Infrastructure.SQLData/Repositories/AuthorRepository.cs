using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        readonly BookShopAppContext _context;

        public AuthorRepository(BookShopAppContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Author> GetAuthors(Filter filter)
        {
            var orderBy = filter.OrderBy;
            var sortBy = filter.SortBy;

            if (filter.ItemsPrPage <= 0 || filter.CurrentPage <= 0) return _context.Authors;
            
            if (sortBy != null)
            {
                var propertyInfo = typeof(Book).GetProperty(filter.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if(orderBy == "asc" || orderBy == null)
                {
                    return _context.Authors.OrderBy(x => propertyInfo.GetValue(x,
                            null))
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                        .Take(filter.ItemsPrPage);
                }
                if(orderBy == "desc"){
                    return _context.Authors.OrderByDescending(x => propertyInfo.GetValue(x,
                            null))
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                        .Take(filter.ItemsPrPage);
                }
            }
            
            if(orderBy == "asc" || orderBy == null)
            {
                return _context.Authors.OrderBy(a => a.ID).Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }
            
            if(orderBy == "desc"){
                return _context.Authors.OrderByDescending(a => a.ID).Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }

            return _context.Authors;
        }

        public Author GetAuthorByID(int Id)
        {
            return _context.Authors.FirstOrDefault(a => a.ID == Id);
        }

        public Author Update(Author authorUpdate)
        {
            _context.Attach(authorUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return authorUpdate;
        }

        public Author Delete(int id)
        {
            var authorToRemove = _context.Authors.Remove(new Author {ID = id}).Entity;
            _context.SaveChanges();
            return authorToRemove;
        }

        public Author CreateAuthor(Author author)
        {
            _context.Attach(author).State = EntityState.Added;
            _context.SaveChanges();
            return author;
        }
    }
}