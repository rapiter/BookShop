using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService
{
    public interface IAuthorService
    {
        Author CreateNewAuthor(String firstName, String lastName, DateTime birthDate);
        Author CreateAuthor(Author author);
        Author Delete(Author author);
        Author Update(Author authorUpdate);
        List<Author> GetAuthors();
        Author ReadById(int Id);
    }
}