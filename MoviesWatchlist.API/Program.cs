using Microsoft.EntityFrameworkCore;
using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Persistence;
using MoviesWatchlist.Persistence.Context;
using MoviesWatchlist.Persistence.Repositories;
using MoviesWatchlist.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWatchListService, WatchListService>();
builder.Services.AddScoped<IWatchListItemRepository, WatchListItemRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

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