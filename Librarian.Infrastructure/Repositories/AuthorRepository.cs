using Librarian.Infrastructure.EntityFramework;

namespace Librarian.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {

        }
    }
}