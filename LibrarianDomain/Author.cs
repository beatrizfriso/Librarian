using System.Collections.Generic;
using Librarian.Domain.Entities.Base;

namespace Librarian.Domain
{
    public class Author : Entity
    {
        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }

    }
}