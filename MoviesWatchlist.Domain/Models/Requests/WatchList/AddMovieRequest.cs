namespace MoviesWatchlist.Domain.Models.Requests.WatchList;

public class AddMovieRequest
{
    public int UserId { get; set; }
    public string MovieId { get; set; }
}