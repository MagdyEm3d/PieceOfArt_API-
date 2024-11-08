using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.ConnectionDbContext;
using PiecesOfArt_Application_Assignment.Reposatories;
using PiecesOfArt_Application_Assignment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connection));
builder.Services.AddScoped<IUserReposatory, UserRepository>();
builder.Services.AddScoped<ICategoryReposatory, CategoryRepository>();
builder.Services.AddScoped<ILoyaltCardReposatoy, LoyaltyCardRepository>();
builder.Services.AddScoped<IPieceOfArtReposatory, PieceOfArtRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
