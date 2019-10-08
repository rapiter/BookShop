using System;
using System.Collections.Generic;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository AuthorRepository;
        
        public AuthorService(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        public Author CreateNewAuthor(string firstName, string lastName, DateTime birthDate)
        {
            throw new NotImplementedException();
        }

        public Author CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Author Delete(Author author)
        {
            throw new NotImplementedException();
        }

        public Author Update(Author authorUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return AuthorRepository.GetAuthors();
        }

        public Author GetAuthorByID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}