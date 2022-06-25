using MoviesWatchlist.Domain.Abstractions.Repositories;
using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Persistence.Context;

namespace MoviesWatchlist.Persistence.Repositories;

public class WatchListItemRepository : IWatchListItemRepository
{
    private readonly ApplicationDbContext _context;
    
    public WatchListItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Insert(int userId, string movieId)
    {
        var watchListItem = new WatchListItem { UserId = userId, MovieId = movieId };
        _context.Add(watchListItem);
        _context.SaveChanges();
    }

    public List<WatchListItem> Get(int userId)
    {
        var watchListItems = _context.WatchListItems.Where(w => w.UserId == userId);
        return watchListItems.ToList();
    }
}