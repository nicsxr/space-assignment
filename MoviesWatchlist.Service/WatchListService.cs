using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Service;

public class WatchListService : IWatchListService
{
    private readonly IWatchListItemRepository _repo;

    public WatchListService(IWatchListItemRepository repo)
    {
        _repo = repo;
    }
    
    public Task<MovieItem> AddMovie(int userId, string movieId)
    {
        // TODO: MAPPER IMPLEMENTATION
        var movie = new MovieItem() { UserId = userId, MovieId = movieId };
        _repo.Insert(userId, movieId);
        
        return Task.FromResult(movie);
    }

    public Task<List<MovieItem>> GetWatchlistMovies(int userId)
    {
        throw new NotImplementedException();
    }
}