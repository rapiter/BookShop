using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        readonly BookShopAppContext context;

        public AuthorRepository(BookShopAppContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors;
        }

        public Author GetAuthorByID(int Id)
        {
            return context.Authors.FirstOrDefault(a => a.ID == Id);
        }

        public Author Update(Author authorUpdate)
        {
            context.Attach(authorUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return authorUpdate;
        }

        public Author Delete(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
            return null;
        }

        public Author CreateAuthor(Author author)
        {
            context.Attach(author).State = EntityState.Added;
            context.SaveChanges();
            return author;
        }
    }
}