using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService
{
    public interface IAuthorService
    {
        Author CreateNewAuthor(String firstName, String lastName, DateTime birthDate);
        Author CreateAuthor(Author author);
        Author Delete(int id);
        Author Update(Author authorUpdate);
        IEnumerable<Author> GetAuthors();
        Author GetAuthorByID(int Id);
        IEnumerable<Author> GetFilteredAuthors(Filter filter);

    }
}