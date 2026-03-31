using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using Musicianfinder_Back.ApplicationCore.Services;
using MusicianFinder_Back.Infrastructure;
using MusicianFinder_Back.Infrastructure.Repositories;
using MusicianFinder_Back.WebAPI.Token;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// - Tools (TokenTool TODO)


// - Services
builder.Services.AddScoped<IMusicianService, MusicianService>();

// - Repositories
builder.Services.AddScoped<IMusicianRepository, MusicianRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// - Token
builder.Services.AddScoped<TokenTool>();


builder.Services.AddControllers();

// Configuration des authentifications par JWT
// -> ne pas oublier d'ajouter le package "Microsoft.AspNetCore.Authentication.JwtBearer - OK
// -> ne pas oublier de l'ajouter dans la partie "app" (UseAuthentication) - OK
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        byte[] secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"]!);

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            // Valeurs valides pour la config du token
            ValidIssuer = builder.Configuration["Token:Issuer"], // Token:Issuer -> venant de appsettings.json
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),

            // Règles de validation
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true, // valide clé et signature du token
            ValidateLifetime = true // valide la durée de vie
        };
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// CORS pour autoriser le frontend à faire des requêtes vers le backend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5174")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// App-----------------
var app = builder.Build();

// Appliquer CORS — doit être AVANT UseAuthentication et UseAuthorization
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Pour activer dans l'app l'authentification (JWT) configurée plus haut
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
