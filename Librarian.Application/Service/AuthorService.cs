using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Author;
using Librarian.Application.DTOs.Response;
using Librarian.Application.Mapper;
using Librarian.Application.Service.Interface;

namespace Librarian.Application.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IBaseRepository<Author> _authorRepository;
    
        public AuthorService(IBaseRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<AuthorResponse> GetAll()
        {
            var authorList = _authorRepository.GetAll();
            return authorList.Select(AuthorMapper.ToAuthorResponse).ToList();
        }

        public AuthorResponse GetById(GetByIdRequest request)
        {
            var entity = _authorRepository.GetById(request.Uid);
            return AuthorMapper.ToAuthorResponse(entity);
        }

        public Author InsertAuthor(AuthorRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Invalid author name");
            }

            Author author = new Author(request.Name);
            _authorRepository.Insert(author);
            return author;
        }

        public Author UpdateAuthor(UpdateAuthorRequest updatedAuthor)
        {
            if (string.IsNullOrEmpty(updatedAuthor.Name))
            {
                throw new ArgumentException("Invalid author name");
            }

            var author = _authorRepository.GetById(updatedAuthor.Uid);
            author.Name = updatedAuthor.Name;
            _authorRepository.Update(author);
            return author;
        }

        public bool DeleteAuthor(Guid id)
        {
            _authorRepository.Delete(id);
            return true;
        }
    }
}