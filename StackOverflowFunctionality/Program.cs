using Microsoft.EntityFrameworkCore;
using StackOverflowFunctionality.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StackOverflowFunctionalityContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("StackOverflowConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<StackOverflowFunctionalityContext>();

var pendingMigrations = dbContext.Database.GetPendingMigrations();
if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

app.MapGet("data", async (StackOverflowFunctionalityContext db) =>
{
    var usersGroupedByAnswers = await db.Answers
        .Include(a => a.User)
        .Where(a => a.AnswerAuthorId == a.User.Id)
        .GroupBy(a=>a.User.Nickname)
        .Select(a =>new{AuthorsNicknames = a.Key, NumsOfAnswers = a.Count()})
        .ToListAsync();
    
    return usersGroupedByAnswers;
});

app.MapPost("update", async (StackOverflowFunctionalityContext db) =>
{
    User user = await db.Users.FirstAsync(u => u.Nickname == "Justine76");

   user.Answers.Add(new Answer(){QuestionId = 1, Reply = "You should be aware of constraints in mssql and maybe think about new db provider."});

    await db.SaveChangesAsync();
});

app.MapPost("create", async (StackOverflowFunctionalityContext db) =>
{
    var user = new User()
    {
        Nickname = "DeJong213",
        Email = "mail.test@fakedomain.com"
    };
    var question = new Question()
    {
        Header = "How to reset id counting to 0?",
        Content = "When I remove all rows from table, counting starts from the last deleted id.",
        User = user
    };

    db.Questions.Add(question);
    await db.SaveChangesAsync();
});

// The solution for like and dislike mechanism is strongly simplified, since I haven't learned asp yet.
// In the final project I would also add a bool property to the User class to check if he already voted
// (currently the user is able of liking and disliking question, answer or comment many times).
// It doesn't make sense at this moment because without proper environment I can't check which user is voting.  
app.MapPost("like", async (StackOverflowFunctionalityContext db) =>
{
    // user input
    var questionChoiceById = 1;
    //

    Question question = await db.Questions.FirstAsync(q => q.Id == questionChoiceById);

    question.Points++;

    await db.SaveChangesAsync();
});
app.MapPost("dislike", async (StackOverflowFunctionalityContext db) =>
{
    // user input
    var questionChoiceById = 1;
    //

    Question question = await db.Questions.FirstAsync(q => q.Id == questionChoiceById);

    question.Points--;

    await db.SaveChangesAsync();
});

app.MapDelete("delete", async (StackOverflowFunctionalityContext db) =>
{
    var user = await db.Users.FirstAsync(u => u.Nickname == "Adelbert23");

    var userQuestions = db.Questions.Where(q => q.QuestionAuthorId == user.Id).ToList();
    db.RemoveRange(userQuestions);

    await db.SaveChangesAsync();
});

//DataGenerator.Seed(dbContext);
app.Run();