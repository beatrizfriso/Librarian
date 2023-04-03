﻿using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Book;
using Librarian.Application.DTOs.Response;

namespace Librarian.Application.Service.Interface
{
    public interface IBookService
    {
        List<BookResponse> GetAll();
        BookResponse GetById(GetByIdRequest request);
        Book InsertBook(BookRequest newBook);
        bool DeleteBook(Guid id);
        Book UpdateBook(UpdateBookRequest updatedBook);
    }
}