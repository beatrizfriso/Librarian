using Librarian.Application.Service;
using Librarian.Application.Service.Interface;
using Librarian.Domain;
using Librarian.Infrastructure.Repositories;
using Librarian.Infrastructure.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Librarian.Application;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection ApplicationDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IAuthorService, AuthorService>();
        services.AddTransient<IGenreService, GenreService>();
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IBaseRepository<Author>, AuthorRepository>();
        services.AddTransient<IBaseRepository<Genre>, GenreRepository>();
        services.AddTransient<IBaseRepository<Book>, BookRepository>();

        return services;
    }
}