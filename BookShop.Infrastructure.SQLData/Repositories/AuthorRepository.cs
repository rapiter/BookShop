using System;
using System.Collections.Generic;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
    

        public List<Author> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public Author ReadById(int Id)
        {
            throw new NotImplementedException();
        }

        public Author Update(Author authorUpdate)
        {
            throw new NotImplementedException();
        }

        public Author Delete(Author author)
        {
            throw new NotImplementedException();
        }

        public Author CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}