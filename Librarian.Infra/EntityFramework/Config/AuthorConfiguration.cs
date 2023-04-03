using Librarian.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Librarian.Infrastructure.EntityFramework.Config
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Uid);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}