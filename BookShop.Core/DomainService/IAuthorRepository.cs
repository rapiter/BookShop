using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.DomainService
{
    public interface IAuthorRepository
    {
        Author CreateAuthor(Author author);
        Author Delete(int id);
        Author Update(Author authorUpdate);
        IEnumerable<Author> GetAuthors(Filter filter = null);
        Author GetAuthorByID(int Id);
    }
}