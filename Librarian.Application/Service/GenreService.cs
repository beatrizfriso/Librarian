using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Author;
using Librarian.Application.DTOs.Request.Genre;
using Librarian.Application.DTOs.Response;
using Librarian.Application.Mapper;

namespace Librarian.Application.Service
{
    public class GenreService : IGenreService
    {
        private readonly IBaseRepository<Genre> _genreRepository;
    
        public GenreService(IBaseRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public bool DeleteGenre(Guid id)
        {
            _genreRepository.Delete(id);
            return true;
        }

        public List<GenreResponse> GetAll()
        {
            var genreList = _genreRepository.GetAll();
            return genreList.Select(c => GenreMapper.ToGenreResponse(c)).ToList();
        }

        public GenreResponse GetById(GetByIdRequest request)
        {
            var entity = _genreRepository.GetById(request.Uid);
            return GenreMapper.ToGenreResponse(entity);
        }

        public Genre UpdateGenre(UpdateAuthorRequest updatedGenre)
        {
            if (string.IsNullOrEmpty(updatedGenre.Name))
            {
                throw new ArgumentException("Invalid genre name");
            }

            var genre = _genreRepository.GetById(updatedGenre.Uid);
            genre.Name = updatedGenre.Name;
            _genreRepository.Update(genre);

            return genre;
        }

        public Genre InsertGenre(GenreRequest newGenre)
        {
            if (string.IsNullOrEmpty(newGenre.Name))
            {
                throw new ArgumentException("Invalid genre name");
            }
        
            Genre genre = new Genre(newGenre.Name);
            _genreRepository.Insert(genre);
        
            return genre;
        }
}