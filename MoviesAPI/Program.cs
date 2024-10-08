using Microsoft.EntityFrameworkCore;
using MoviesAPI.DAL;
using MoviesAPI.Data;
using MoviesAPI.Decorators;
using MoviesAPI.Repositories;
using MoviesAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<MovieServiceCacheDecorator>();
builder.Services.AddScoped<IMovieService, MovieServiceLoggingDecorator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddMemoryCache();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
    dbContext.Database.Migrate();
}

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
