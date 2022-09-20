using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StackOverflowFunctionality.Entities
{
    public class StackOverflowFunctionalityContext : DbContext
    {
        public StackOverflowFunctionalityContext(DbContextOptions<StackOverflowFunctionalityContext> options) : base(options)
        {

        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date>(eb =>
            {
                eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Answer>(eb =>
            {
                eb.Property(a => a.Reply).IsRequired();

                eb.HasOne(a => a.User)
                    .WithMany(u => u.Answers)
                    .HasForeignKey(a => a.AnswerAuthorId);

                eb.HasOne(a => a.Question)
                    .WithMany(q => q.Answers)
                    .HasForeignKey(a => a.QuestionId);

                eb.HasOne(a => a.Rating)
                    .WithOne(r => r.Answer)
                    .HasForeignKey<Rating>(a => a.AnswerRatingId);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(c => c.Message).IsRequired();

                eb.HasOne(c => c.Question)
                    .WithMany(q => q.Comments)
                    .HasForeignKey(c => c.QuestionCommentId);

                eb.HasMany(c => c.Tags)
                    .WithMany(t => t.Comments)
                    .UsingEntity<CommentTag>(
                        c => c
                            .HasOne(ct => ct.Tag)
                            .WithMany()
                            .HasForeignKey(ct => ct.TagId),

                            c => c
                            .HasOne(ct => ct.Comment)
                            .WithMany()
                            .HasForeignKey(ct => ct.CommentId),

                        ct =>
                        {
                            ct.HasKey(x => new { x.TagId, x.CommentId });
                            ct.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                        }

                        );
            });

            modelBuilder.Entity<Question>(eb =>
            {
                eb.Property(q => q.Header)
                    .IsRequired()
                    .HasMaxLength(200);

                eb.Property(a => a.Content).IsRequired();

                eb.HasOne(q => q.User)
                    .WithMany(u => u.Questions)
                    .HasForeignKey(q => q.QuestionAuthorId);

                eb.HasOne(q => q.Rating)
                    .WithOne(r => r.Question)
                    .HasForeignKey<Rating>(q => q.QuestionRatingId);
            });

            modelBuilder.Entity<Rating>(eb =>
            {
                eb.Property(r => r.Points)
                    .IsRequired()
                    .HasDefaultValue(0);
            });

            modelBuilder.Entity<Tag>(eb =>
            {
                eb.Property(t => t.Value).IsRequired();
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.Property(u => u.Nickname).IsRequired();
                eb.Property(u => u.Email).IsRequired();
            });
        }
    }
}
