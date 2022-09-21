using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowFunctionality.Entities.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> eb)
        {
            eb.Property(q => q.Header)
                .HasMaxLength(200);

            eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
            eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();
            eb.Property(d => d.Points).HasDefaultValue(0);

            eb.HasOne(q => q.User)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.QuestionAuthorId);

            eb.HasMany(q => q.Tags)
                .WithMany(t => t.Questions)
                .UsingEntity<QuestionTag>
                (
                    q => q
                        .HasOne(qt => qt.Tag)
                        .WithMany()
                        .HasForeignKey(ct => ct.TagId),

                    c => c
                        .HasOne(ct => ct.Question)
                        .WithMany()
                        .HasForeignKey(qt => qt.QuestionId),

                    qt =>
                    {
                        qt.HasKey(x => new { x.TagId, x.QuestionId });
                        qt.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                    }
                );
        }
    }
}
