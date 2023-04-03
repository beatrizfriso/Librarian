using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Author;
using Librarian.Application.DTOs.Request.Genre;
using Librarian.Application.DTOs.Response;
using Librarian.Domain;

namespace Librarian.Application.Service.Interface
{
    public interface IGenreService
    {
        List<GenreResponse> GetAll();
        GenreResponse GetById(GetByIdRequest request);
        Genre InsertGenre(GenreRequest newGenre);
        bool DeleteGenre(Guid id);

        Genre UpdateGenre(UpdateAuthorRequest updatedGenre);
    }
}