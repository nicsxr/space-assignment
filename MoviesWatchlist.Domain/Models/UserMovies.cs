namespace MoviesWatchlist.Domain.Models;

public class UserMovies
{
    public int UserId { get; set; }
    public List<string> MovieIds { get; set; }
}