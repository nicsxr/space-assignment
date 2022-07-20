using MoviesWatchlist.Domain.Entities;

namespace MoviesWatchlist.Domain.Abstractions.Repositories;

public interface IWatchListItemRepository
{
    Task<bool> Insert(int userId, string movieId);
    Task<List<WatchListItem>> Get(int userId);
    Task<bool> MarkAsWatched(int userId, string movieId);
    Task<List<WatchListItem>> GetUnwatchedMovies();
}