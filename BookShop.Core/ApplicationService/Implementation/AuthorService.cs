using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author CreateNewAuthor(string firstName, string lastName, DateTime birthDate)
        {
            var a = new Author()
            {
                Firstname = firstName,
                Lastname = lastName,
                Birthdate = birthDate
            };
            IsNullOrEmpty.Check(a);
            return _authorRepository.CreateAuthor(a);
        }

        public Author CreateAuthor(Author author)
        {
            IsNullOrEmpty.Check(author);
            return _authorRepository.CreateAuthor(author);
        }

        public Author Delete(int id)
        {
            return _authorRepository.Delete(id);
        }

        public Author Update(Author authorUpdate)
        {
            return _authorRepository.Update(authorUpdate);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _authorRepository.GetAuthors();
        }

        public Author GetAuthorByID(int id)
        {
            return _authorRepository.GetAuthorByID(id);
        }
        
        public IEnumerable<Author> GetFilteredAuthors(Filter filter)
        {
            return _authorRepository.GetAuthors(filter).ToList();
        }
    }
}