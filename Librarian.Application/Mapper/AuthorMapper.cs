using Librarian.Application.DTOs.Response;

namespace Librarian.Application.Mapper
{
    public class AuthorMapper
        {
            public static AuthorResponse ToAuthorResponse(Author author)
            {
                var dto = new AuthorResponse();
                dto.Uid = author.Uid;
                dto.Name = author.Name;
                return dto;
            }
        }
    }