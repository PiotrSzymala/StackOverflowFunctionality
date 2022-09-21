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
