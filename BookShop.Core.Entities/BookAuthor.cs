namespace BookShop.Core.Entities
{
    public class BookAuthor
    {
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}