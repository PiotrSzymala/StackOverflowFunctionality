using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace StackOverflowFunctionality.Entities
{
    public class DataGenerator
    {
        public static void Seed(StackOverflowFunctionalityContext context)
        {
            var userGenerator = new Faker<User>()
                .RuleFor(u => u.Nickname, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email());

            var users = userGenerator.Generate(100);

            context.AddRange(users);
            context.SaveChanges();

        }
    }
}
