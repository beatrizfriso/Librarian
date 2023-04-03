using System;

namespace Librarian.Application.DTOs.Request.Book
{
    public class BookRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LibraryStatus Status { get; set; }
        public BookType Type { get; set; }
        public int Pages { get; set; }
        public Guid GenreId { get; set; }
        public Guid AuthorId { get; set; }
    }
}