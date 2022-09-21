using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowFunctionality.Entities.Configurations
{
    public class CommentConfiguration:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> eb)
        {
            eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();
            eb.Property(d => d.Points).HasDefaultValue(0);

            eb.HasOne(c => c.Question)
                .WithMany(q => q.Comments)
                .HasForeignKey(c => c.QuestionCommentId);
        }
    }
}
