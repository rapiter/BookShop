using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BookShopAppContext _context;

        public GenreRepository(BookShopAppContext context)
        {
            _context = context;
        }
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
