namespace MoviesWatchlist.Domain.Entities;

public class WatchListItem
{
    public int UserId { get; set; }
    public string MovieId { get; set; }
    public bool IsWatched { get; set; }
    public DateTime? LastNotification { get; set; }
    
}