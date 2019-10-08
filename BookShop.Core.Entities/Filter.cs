using System;

namespace BookShop.Core.Entities
{
    public class Filter
    {
        public int CurrentPage { get; set; }
        public int ItemsPrPage { get; set; }
        public String OrderBy { get; set; }
        public String SortBy { get; set; }
    }
}