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


            modelBuilder.Entity<Answer>(eb =>
            {
                eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();

                eb.HasOne(a => a.Question)
                    .WithMany(q => q.Answers)
                    .HasForeignKey(a => a.QuestionId);

                eb.HasOne(a => a.Rating)
                    .WithOne(r => r.Answer)
                    .HasForeignKey<Rating>(a => a.AnswerRatingId);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();


                eb.HasOne(c => c.Question)
                    .WithMany(q => q.Comments)
                    .HasForeignKey(c => c.QuestionCommentId);
            });

            modelBuilder.Entity<Question>(eb =>
            {
                eb.Property(q => q.Header)
                    .HasMaxLength(200);

                eb.Property(d => d.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(d => d.UpdatedDate).ValueGeneratedOnUpdate();

                eb.HasOne(q => q.User)
                    .WithMany(u => u.Questions)
                    .HasForeignKey(q => q.QuestionAuthorId);

                eb.HasOne(q => q.Rating)
                    .WithOne(r => r.Question)
                    .HasForeignKey<Rating>(q => q.QuestionRatingId)
                    .OnDelete(DeleteBehavior.NoAction);


                eb.HasMany(q => q.Tags)
                    .WithMany(t => t.Questions)
                    .UsingEntity<QuestionTag>(
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


            });

            modelBuilder.Entity<Rating>(eb =>
            {
                eb.Property(r => r.Points)
                    .HasDefaultValue(0);
            });

            modelBuilder.Entity<Tag>(eb =>
            {
                eb.HasData(new Tag() { Id = 1, Value = "C#" },
                    new Tag() { Id = 2, Value = "SQL" },
                    new Tag() { Id = 3, Value = "Python" },
                    new Tag() { Id = 4, Value = "Java" }
                );
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasMany(u => u.Answers)
                    .WithOne(a => a.User)
                    .HasForeignKey(a => a.AnswerAuthorId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
