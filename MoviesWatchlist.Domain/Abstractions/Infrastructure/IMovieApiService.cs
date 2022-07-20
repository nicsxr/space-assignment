using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Domain.Abstractions.Infrastructure;

public interface IMovieApiService
{
    public Task<SearchMoviesResponse> Search (string title);
    public Task<MovieDetailsResponse> Details(string id, string?[] options);
}