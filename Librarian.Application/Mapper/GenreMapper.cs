namespace Librarian.Application.Mapper
{
    public class GenreMapper
    {
        public static GenreResponse ToGenreResponse(Genre genre)
        {
            var dto = new GenreResponse();
            dto.Uid = genre.Uid;
            dto.Name = genre.Name;

            return dto;
        }
    }
}