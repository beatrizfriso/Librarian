using Librarian.Domain;
using Librarian.Infrastructure.EntityFramework;

namespace Librarian.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public GenreRepository(LibraryContext context) : base(context)
        {

        }
    }
}