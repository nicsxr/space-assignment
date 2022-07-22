using System.Globalization;
using Hangfire;
using MoviesWatchlist.Domain.Abstractions.Infrastructure;
using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Models;
using MoviesWatchlist.EmailService;

namespace MoviesWatchlist.ScheduledService;

public class NotificationSender : INotificationSender
{
    private readonly IEmailSender _email;
    private readonly IWatchListItemRepository _repo;
    private readonly IMovieApiService _movieApi;
    
    public NotificationSender(IEmailSender email, IWatchListItemRepository repo, IMovieApiService movieApi)
    {
        _email = email;
        _repo = repo;
        _movieApi = movieApi;
    }
    
    [AutomaticRetry(Attempts = 0)]
    public async Task SendNotifications()
    {
        var userMovies = await _repo.GetUnwatchedMovies();
        
        if (userMovies.Count == 0) return;
        
        foreach (var userMovie in userMovies)
        {
            MovieDetailsResponse movie = new();

            float highestRating = 0;
            
            foreach (var movieId in userMovie.MovieIds)
            {
                string[] options = Array.Empty<string>();
                MovieDetailsResponse details = await _movieApi.Details(movieId, options);
                

                float imdbRating = details.ImDbRating != null ? float.Parse(details.ImDbRating, 
                    CultureInfo.InvariantCulture.NumberFormat) : 0;
                
                if (imdbRating > highestRating)
                {
                    highestRating = imdbRating;
                    movie = details;
                }
            }

            
            var receiver = "nikasxirtla@hotmail.com";
            
            var body = @$"<center> <h1>{movie.FullTitle}</h1>
                        <h3>{movie.ImDbRating}/10</h3>
                        <p style='word-wrap: break-word; margin-right:25%; margin-left:25%'>{movie.Plot}</p>
                        <img src='{movie.Image}'> </center>";
            
            await _email.SendEmail(body, receiver);
            await _repo.UpdateMovieNotificationStatus(userMovie.UserId, movie.Id);
        }
    }
}