using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowFunctionality.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> eb)
        {
            eb.HasMany(u => u.Answers)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.AnswerAuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
