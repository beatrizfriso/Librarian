using System.Linq;
using Librarian.Domain;
using Librarian.Domain.Entities.Enums;
using Librarian.Infrastructure.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Librarian.WebAPI;

public static class Extensions
{
    public static void SeedDatabase(this IServiceCollection _serviceCollection)
    {
        using (ServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider())
        {
            var context = serviceProvider.GetRequiredService<LibraryContext>();

            context.Database.EnsureCreated();

            if(context.Books.Any())
            {
                return;
            }

            var author = context.Authors.Add(new Author("Machado de Assis"));
            
            var genre = context.Genres.Add(new Genre("Romance"));

            context.Books.Add(new Book()
            {
                Name = "Dom Casmurro",
                AuthorId = author.Entity.Uid,
                GenreId = genre.Entity.Uid,
                Status = LibraryStatus.Read,
                Type = BookType.Ebook,
                Description = "teste teste",
                Pages = 300
            });

            context.SaveChanges();
        }
    }
}