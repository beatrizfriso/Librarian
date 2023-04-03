using System;

namespace Librarian.Application.DTOs.Request.Book
{
    public class UpdateBookRequest
    {
        [Required]
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LibraryStatus Status { get; set; }
        public enum Type { ebook, physical }
        public int Pages { get; set; }
        public Guid GenreId { get; set; }
        public Guid AuthorId { get; set; }
    }
}