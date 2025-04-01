using ClubSportif.BLL.Interfaces;
using ClubSportif.BLL.Services;
using ClubSportif.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;
using ClubSportif.BLL;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la cha�ne de connexion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Ajout du DbContext avec SQL Server
builder.Services.AddDbContext<ClubSportifDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ClubSportif")));

// Configuration de JwtSettings via le fichier appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// Enregistrement du service AuthService
builder.Services.AddScoped<IAuthService, AuthService>();

// Injection des services BLL
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IConvocationMatchService, ConvocationMatchService>();
builder.Services.AddScoped<IConvocationTournoiService, ConvocationTournoiService>();
builder.Services.AddScoped<ITournoiService, TournoiService>();
builder.Services.AddScoped<IClubService, ClubService>();



// Ajout des services et configuration des controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();