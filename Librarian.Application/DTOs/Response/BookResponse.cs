namespace Librarian.Application.DTOs.Response
{
    public class BookResponse
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LibraryStatus Status { get; set; }
        public BookType Type { get; set; }
        public int Pages { get; set; }
        public GenreResponse GenreId { get; set; }
        public AuthorResponse AuthorId { get; set; }
    }
}