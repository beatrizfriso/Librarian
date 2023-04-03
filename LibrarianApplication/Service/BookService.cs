using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Book;
using Librarian.Application.DTOs.Response;
using Librarian.Application.Mapper;
using Librarian.Application.Service.Interface;
using Librarian.Domain;
using Librarian.Infrastructure.Repositories.Interface;

namespace Librarian.Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _bookRepository;

        public BookService(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public bool DeleteBook(Guid id)
        {
            _bookRepository.Delete(id);
            return true;
        }

        public List<BookResponse> GetAll()
        {
            var bookList = _bookRepository.GetAll();
            return bookList.Select(BookMapper.ToBookResponse).ToList();
        }

        public BookResponse GetById(GetByIdRequest request)
        {
            var entity = _bookRepository.GetById(request.Uid);
            return BookMapper.ToBookResponse(entity);
        }

        public Book InsertBook(BookRequest newBook)
        {
            if (string.IsNullOrEmpty(newBook.Name))
            {
                throw new ArgumentException("Invalid book name");
            }

            Book book = new Book
            {
                Name = newBook.Name,
                Description = newBook.Description,
                Pages = newBook.Pages,
                Status = newBook.Status,
                AuthorId = newBook.AuthorId,
                GenreId = newBook.GenreId,
            };

            _bookRepository.Insert(book);
            return book;
        }

        public Book UpdateBook(UpdateBookRequest updatedBook)
        {
            if (string.IsNullOrEmpty(updatedBook.Name))
            {
                throw new ArgumentException("Invalid book name");
            }

            var book = _bookRepository.GetById(updatedBook.Uid);
            book.Uid = updatedBook.Uid;
            book.Name = updatedBook.Name;
            book.Description = updatedBook.Description;
            book.Status = updatedBook.Status;
            book.Pages = updatedBook.Pages;
            book.AuthorId = updatedBook.AuthorId;
            book.GenreId = updatedBook.GenreId;
            _bookRepository.Update(book);
            return book;
        }
    }
}