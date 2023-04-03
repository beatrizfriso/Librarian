using System;
using System.Collections.Generic;
using Librarian.Domain;

namespace Librarian.Infrastructure.Repositories.Interface
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(Guid id);
        void InsertBook(Book newBook);
        void DeleteBook(Guid id);
        void UpdateBook(Book updatedBook, Guid Uid);
    }
}