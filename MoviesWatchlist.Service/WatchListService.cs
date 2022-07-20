using AutoMapper;
using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Service;

public class WatchListService : IWatchListService
{
    private readonly IWatchListItemRepository _repo;
    private readonly IMapper _mapper;

    public WatchListService(IWatchListItemRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<bool> AddMovie(int userId, string movieId)
    {
        return await _repo.Insert(userId, movieId);
    }

    public async Task<List<MovieItem>> GetWatchlistMovies(int userId)
    {
        var movies = await _repo.Get(userId);
        
        return _mapper.Map<List<WatchListItem>, List<MovieItem>>(movies);
    }

    public async Task<bool> MarkAsWatched(int userId, string movieId)
    {
        var movies = await _repo.Get(userId);
        var movie = movies.Find(x => x.MovieId == movieId);
        if (movie != null) movie.IsWatched = true;
        return await _repo.MarkAsWatched(userId, movieId);
    }
}