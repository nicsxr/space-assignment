using MoviesWatchlist.Domain.Entities;

namespace MoviesWatchlist.Domain.Abstractions.Repositories;

public interface IWatchListItemRepository
{
    void Insert(int userId, string movieId);
    List<WatchListItem> Get(int userId);
}