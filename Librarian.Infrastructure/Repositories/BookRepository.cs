namespace Librarian.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        {

        }

        public override List<Book> GetAll() {
            return _context.Books.Include(x => x.Author).Include(x => x.Genre).ToList();
        }
    }
}