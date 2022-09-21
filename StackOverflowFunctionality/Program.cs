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
});

app.MapPost("update", async (StackOverflowFunctionalityContext db) =>
{
    User user = await db.Users.FirstAsync(u => u.Nickname == "Justine76");

   user.Answers.Add(new Answer(){QuestionId = 1, Reply = "You should be aware of constraints in mssql and maybe think about new db provider."});

    await db.SaveChangesAsync();
});

app.MapPost("create", async (StackOverflowFunctionalityContext db) =>
{
    
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