using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Domain.Abstractions.Services;

public interface IWatchListService
{
    Task<MovieItem> AddMovie(int userId, string movieId);
    Task<List<MovieItem>> GetWatchlistMovies(int userId);
}