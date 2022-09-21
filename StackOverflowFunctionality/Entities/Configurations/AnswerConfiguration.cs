using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowFunctionality.Entities.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> eb)
        {
            eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();
            eb.Property(d => d.Points).HasDefaultValue(0);

            eb.HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);
        }
    }
}
