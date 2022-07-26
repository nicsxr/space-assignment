using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesWatchlist.Domain.Abstractions.Infrastructure;
using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Infrastructure;
using MoviesWatchlist.Persistence;
using MoviesWatchlist.Persistence.Context;
using MoviesWatchlist.Persistence.Repositories;
using MoviesWatchlist.Service;
using MoviesWatchlist.Service.Mapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.MemoryStorage;
using MoviesWatchlist.Domain.Models.Validation.Movies;
using MoviesWatchlist.Domain.Models.Validation.WatchList;
using MoviesWatchlist.EmailService;
using MoviesWatchlist.ScheduledService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<SearchMoviesRequestValidator>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations());

builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseDefaultTypeSerializer()
        .UseMemoryStorage());
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IWatchListService, WatchListService>();
builder.Services.AddScoped<IWatchListItemRepository, WatchListItemRepository>();
builder.Services.AddScoped<IMovieApiService, MovieApiService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<INotificationSender, NotificationSender>();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHttpClient("IMDB", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("MovieApi")["URI"]!);
});

var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/dashboard");

RecurringJob.AddOrUpdate("Send Emails to users", () => 
        builder.Services.BuildServiceProvider().GetService<INotificationSender>()!.SendNotifications(),
    "0 30 19 * * SUN", TimeZoneInfo.Local);

app.Run();