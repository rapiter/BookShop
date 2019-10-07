using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.DomainService
{
    public interface IAuthorRepository
    {
        Author CreateAuthor(Author author);
        Author Delete(Author author);
        Author Update(Author authorUpdate);
        List<Author> GetAuthors();
        Author ReadById(int Id);
    }
}