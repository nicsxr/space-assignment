using Microsoft.EntityFrameworkCore;
using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Persistence.Context;

namespace MoviesWatchlist.Persistence.Repositories;

public class WatchListItemRepository : IWatchListItemRepository
{
    private readonly ApplicationDbContext _db;

    public WatchListItemRepository(ApplicationDbContext context)
    {
        _db = context;
    }

    public async Task<bool> Insert(int userId, string movieId)
    {
        _db.Add(new WatchListItem { UserId = userId, MovieId = movieId });
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<List<WatchListItem>> Get(int userId)
    {
        var watchListItems = _db.WatchListItems.Where(listItem => listItem.UserId == userId);
        return await watchListItems.ToListAsync();
    }

    public async Task<bool> MarkAsWatched(int userId, string movieId)
    {
        var movie = await _db.WatchListItems.FirstOrDefaultAsync(listItem => listItem.UserId == userId
                                                                             && listItem.MovieId == movieId);
        if (movie != null)
        {
            movie.IsWatched = true;
        }
        else
        {
            throw new Exception();
        }

        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<List<WatchListItem>> GetUnwatchedMovies()
    {
        DateTime lastMonth = DateTime.Now.AddMonths(-1);

        var unwatchedMovies = await _db.WatchListItems.Where(listItem => listItem.IsWatched == false
                                                            && listItem.LastNotification < lastMonth).ToListAsync();

        return unwatchedMovies;
    }
}