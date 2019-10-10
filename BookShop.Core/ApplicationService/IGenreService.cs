using BookShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Core.ApplicationService
{
    public interface IGenreService
    {
        List<Genre> GetGenres();
    }
}
