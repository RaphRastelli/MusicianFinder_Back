using Microsoft.EntityFrameworkCore;
using Musicianfinder_Back.ApplicationCore.Interfaces.Repositories;
using Musicianfinder_Back.ApplicationCore.Interfaces.Services;
using Musicianfinder_Back.ApplicationCore.Services;
using MusicianFinder_Back.Infrastructure;
using MusicianFinder_Back.Infrastructure.Repositories;
using Scalar.AspNetCore;

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


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// App-----------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
