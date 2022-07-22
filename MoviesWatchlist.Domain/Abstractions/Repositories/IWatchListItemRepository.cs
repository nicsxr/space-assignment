using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Domain.Abstractions.Repositories;

public interface IWatchListItemRepository
{
    Task<bool> Insert(int userId, string movieId);
    Task<List<WatchListItem>> Get(int userId);
    Task<List<WatchListItem>> GetUserUnwatchedMovies(int userId);
    Task<bool> MarkAsWatched(int userId, string movieId);
    Task<List<UserMovies>> GetUnwatchedMovies();
    Task<bool> UpdateMovieNotificationStatus(int userId, string movieId);
}