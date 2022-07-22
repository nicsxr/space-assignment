using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Domain.Abstractions.Services;

public interface IWatchListService
{
    Task<bool> AddMovie(int userId, string movieId);
    Task<List<MovieItem>> GetWatchlistMovies(int userId);
    Task<List<MovieItem>> GetUnwatchedMovies(int userId);

    Task<bool> MarkAsWatched(int userId, string movieId);
}