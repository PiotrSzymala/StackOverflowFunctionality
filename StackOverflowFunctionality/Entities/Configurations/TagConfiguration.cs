using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowFunctionality.Entities.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> eb)
        {
            eb.HasData
            (
                new Tag() { Id = 1, Value = "C#" },
                new Tag() { Id = 2, Value = "SQL" },
                new Tag() { Id = 3, Value = "Python" },
                new Tag() { Id = 4, Value = "Java" }
            );
        }
    }
}
