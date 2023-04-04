using System;
using Librarian.Domain.Entities.Base;
using Librarian.Domain.Entities.Enums;

namespace Librarian.Domain
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LibraryStatus Status { get; set; }
        public BookType Type { get; set; }
        public int Pages { get; set; }
        public Guid GenreId { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }
        
        public bool IsBorrowed { get; set; } = false;
    }
}