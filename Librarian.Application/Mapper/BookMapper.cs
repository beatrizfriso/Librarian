using Librarian.Application.DTOs.Response;

namespace Librarian.Application.Mapper
{
    public class BookMapper
    {
        public static BookResponse ToBookResponse(Book book)
        {
            var dto = new BookResponse();
            dto.Name = book.Name;
            dto.Description = book.Description;
            dto.Status = book.Status;
            dto.Type = book.Type;
            dto.Pages = book.Pages;
            dto.AuthorId = AuthorMapper.ToAuthorResponse(book.Author);
            dto.GenreId = GenreMapper.ToGenreResponse(book.Genre);

            return dto;
        }
    }
}