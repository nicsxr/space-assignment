using Microsoft.AspNetCore.Mvc;
using MoviesWatchlist.Domain.Abstractions.Infrastructure;
using MoviesWatchlist.Domain.Models;
using MoviesWatchlist.Domain.Models.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesWatchlist.API.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : Controller
{
    private readonly IMovieApiService _service;

    public MoviesController(ILogger<WatchListController> logger, IMovieApiService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Search movies.", Description = "Searches IMDB database for movies by keyword.")]
    [ProducesResponseType(typeof(SearchMoviesResponse), 200)]
    [Route("search")]
    public async Task<SearchMoviesResponse> SearchMovie([FromQuery] SearchMoviesRequest searchMoviesRequest)
    {
        return await _service.Search(searchMoviesRequest.Title);
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get movie details.", Description = "Get movie details by providing movie ID.")]
    [ProducesResponseType(typeof(MovieDetailsResponse), 200)]
    [Route("details")]
    public async Task<MovieDetailsResponse> Details([FromQuery] MovieDetailsRequest movieDetailsRequest)
    {
        string?[] options = {movieDetailsRequest.Wikipedia ? "wikipedia" : null, 
                                movieDetailsRequest.Posters ? "posters" : null};
        return await _service.Details(movieDetailsRequest.MovieId, options);
    }
}