namespace MoviesWatchlist.Domain.Models.Requests.WatchList;

public class MarkAsWatchedRequest
{
    public int UserId { get; set; }
    public string MovieId { get; set; }
}