using BookShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Core.DomainService
{
  public interface IGenreRepository
    {
        List<Genre> GetGenres();
    }
}
