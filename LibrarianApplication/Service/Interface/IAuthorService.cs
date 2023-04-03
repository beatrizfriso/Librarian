using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Author;
using Librarian.Application.DTOs.Response;
using Librarian.Domain;

namespace Librarian.Application.Service.Interface;

    public interface IAuthorService
    {
        List<AuthorResponse> GetAll();
        AuthorResponse GetById(GetByIdRequest request);
        Author InsertAuthor(AuthorRequest newAuthor);
        bool DeleteAuthor(Guid id);
        Author UpdateAuthor(UpdateAuthorRequest updatedAuthor);
    }
