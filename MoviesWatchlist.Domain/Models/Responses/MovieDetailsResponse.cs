namespace MoviesWatchlist.Domain.Models;

public class MovieDetailsResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string OriginalTitle { get; set; }
    public string FullTitle { get; set; }
    public string Type { get; set; }
    public string Year { get; set; }
    public string Image { get; set; }
    public string ReleaseDate { get; set; }
    public string RuntimeMins { get; set; }
    public string RuntimeStr { get; set; }
    public string Plot { get; set; }
    public string PlotLocal { get; set; }
    public bool PlotLocalIsRtl { get; set; }
    public string Awards { get; set; }
    public string Directors { get; set; }
    public string Writers { get; set; }
    public string Stars { get; set; }
    public object FullCast { get; set; }
    public string Genres { get; set; }
    public string Companies { get; set; }
    public string Countries { get; set; }
    public string Languages { get; set; }
    public string ContentRating { get; set; }
    public string ImDbRating { get; set; }
    public string ImDbRatingVotes { get; set; }
    public string MetacriticRating { get; set; }
    public object Ratings { get; set; }
    public object Wikipedia { get; set; }
    public object Posters { get; set; }
    public object Images { get; set; }
    public object Trailer { get; set; }
    public object Tagline { get; set; }
    public string Keywords { get; set; }
    public List<string> KeywordList { get; set; }
    public object TvSeriesInfo { get; set; }
    public object TvEpisodeInfo { get; set; }
    public object ErrorMessage { get; set; }
}