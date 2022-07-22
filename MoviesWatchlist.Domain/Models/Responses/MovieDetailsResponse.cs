namespace MoviesWatchlist.Domain.Models;

public class ActorList
{
    public string Id { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public string AsCharacter { get; set; }
}

public class BoxOffice
{
    public string Budget { get; set; }
    public string OpeningWeekendUSA { get; set; }
    public string GrossUSA { get; set; }
    public string CumulativeWorldwideGross { get; set; }
}

public class CompanyList
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class CountryList
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class DirectorList
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class GenreList
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class LanguageList
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class PlotFull
{
    public string PlainText { get; set; }
    public string Html { get; set; }
}

public class PlotShort
{
    public string PlainText { get; set; }
    public string Html { get; set; }
}

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
    public List<DirectorList> DirectorList { get; set; }
    public string Writers { get; set; }
    public List<WriterList> WriterList { get; set; }
    public string Stars { get; set; }
    public List<StarList> StarList { get; set; }
    public List<ActorList> ActorList { get; set; }
    public object FullCast { get; set; }
    public string Genres { get; set; }
    public List<GenreList> GenreList { get; set; }
    public string Companies { get; set; }
    public List<CompanyList> CompanyList { get; set; }
    public string Countries { get; set; }
    public List<CountryList> CountryList { get; set; }
    public string Languages { get; set; }
    public List<LanguageList> LanguageList { get; set; }
    public string ContentRating { get; set; }
    public string? ImDbRating { get; set; }
    public string ImDbRatingVotes { get; set; }
    public string MetacriticRating { get; set; }
    public object Ratings { get; set; }
    public object Wikipedia { get; set; }
    public object Posters { get; set; }
    public object Images { get; set; }
    public object Trailer { get; set; }
    public BoxOffice BoxOffice { get; set; }
    public object Tagline { get; set; }
    public string Keywords { get; set; }
    public List<string> KeywordList { get; set; }
    public List<Similar> Similars { get; set; }
    public object TvSeriesInfo { get; set; }
    public object TvEpisodeInfo { get; set; }
    public object ErrorMessage { get; set; }
}

public class Similar
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string ImDbRating { get; set; }
}

public class StarList
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class WriterList
{
    public string Id { get; set; }
    public string Name { get; set; }
}

