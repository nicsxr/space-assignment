namespace MoviesWatchlist.Domain.Models.Requests;

public class MovieDetailsRequest
{
    public string MovieId { get; set; }
    public bool Wikipedia { get; set; } = false;
    public bool Posters { get; set; } =  false;
}