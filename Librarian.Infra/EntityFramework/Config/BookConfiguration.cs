using Librarian.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librarian.Infrastructure.EntityFramework.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Uid);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Type);
            builder.Property(x => x.Status);
            builder.Property(x => x.Pages);
            builder.Property(x => x.GenreId);
            builder.Property(x => x.AuthorId);

            builder.HasOne(author => author.Author)
                .WithMany(book => book.Books)
                .HasForeignKey(book => book.AuthorId);

            builder.HasOne(book => book.Genre)
                .WithMany(genre => genre.Books)
                .HasForeignKey(book => book.GenreId);

        }
    }
}