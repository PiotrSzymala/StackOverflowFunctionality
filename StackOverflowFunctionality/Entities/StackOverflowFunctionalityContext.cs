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
        public StackOverflowFunctionalityContext(DbContextOptions<StackOverflowFunctionalityContext> options) :base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
