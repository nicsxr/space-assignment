using Microsoft.EntityFrameworkCore;
using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Domain.Models;
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

    public async Task<List<WatchListItem>> GetUserUnwatchedMovies(int userId)
    {
        var watchListItems = _db.WatchListItems.Where(listItem => listItem.UserId == userId 
                && listItem.IsWatched == false);
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

    public async Task<List<UserMovies>> GetUnwatchedMovies()
    {
        DateTime lastDate = DateTime.Now.AddMonths(-1);

        var userIds = await _db.WatchListItems
            .Where(item => item.IsWatched == false)
            .GroupBy(item => item.UserId)
            .Where(grouped => grouped.Count() > 3)
            .Select(grouped => grouped.Key)
            .ToListAsync();
        
        var unwatchedMovies = userIds.Select(userId => new UserMovies
        {
            UserId = userId,
            MovieIds = _db.WatchListItems.Where(item => item.UserId == userId && item.IsWatched == false 
                && (item.LastNotification == null || item.LastNotification < lastDate))
                .Select(item => item.MovieId)
                .ToList(),
        }).ToList();
        
        return unwatchedMovies;
    }

    public async Task<bool> UpdateMovieNotificationStatus(int userId, string movieId)
    {
        var movie = await _db.WatchListItems.FirstAsync(item => item.UserId == userId && item.MovieId == movieId);
        movie.LastNotification = DateTime.Now;
        
        return await _db.SaveChangesAsync() > 0;
    }
}