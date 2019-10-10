using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public List<Genre> GetGenres()
        {
            return _genreRepository.GetGenres();
        }
    }
}
