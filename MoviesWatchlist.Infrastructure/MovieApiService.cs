using System.Diagnostics;
using MoviesWatchlist.Domain.Abstractions.Infrastructure;
using MoviesWatchlist.Domain.Models;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace MoviesWatchlist.Infrastructure;

public class MovieApiService : IMovieApiService
{
    private readonly HttpClient _client;
    private readonly string _apiKey;
    
    public MovieApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _client = httpClientFactory.CreateClient("IMDB");
        _apiKey = configuration.GetSection("MovieApi")["ApiKey"]!;
    }
    
    public async Task<SearchMoviesResponse> Search(string title)
    {
        SearchMoviesResponse result;
        
        string url = $"search/{_apiKey}/{title}";

        var response = await _client.GetAsync(url);

        Debug.WriteLine(response.ToString());
        if (response.IsSuccessStatusCode)
        {
            string contentString = await response.Content.ReadAsStringAsync();
            result = JsonSerializer.Deserialize<SearchMoviesResponse>(contentString,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        }
        else
        {
            throw new HttpRequestException(response.ReasonPhrase);
        }

        return result;
    }

    public async Task<MovieDetailsResponse> Details(string movieId, string?[] options)
    {
        MovieDetailsResponse result;

        string url = $"title/{_apiKey}/{movieId}/{string.Join(",",options)}";

        var response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string contentString = await response.Content.ReadAsStringAsync();
            result = JsonSerializer.Deserialize<MovieDetailsResponse>(contentString,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        }
        else
        {
            throw new HttpRequestException(response.ReasonPhrase);
        }

        return result;
    }
}