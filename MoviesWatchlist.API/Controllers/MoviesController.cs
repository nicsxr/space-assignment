using Microsoft.AspNetCore.Mvc;
using MoviesWatchlist.Domain.Abstractions.Infrastructure;
using MoviesWatchlist.Domain.Models;
using MoviesWatchlist.Domain.Models.Requests;

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
    [Route("search")]
    public async Task<SearchMoviesResponse> SearchMovie([FromQuery] SearchMoviesRequest searchMoviesRequest)
    {
        return await _service.Search(searchMoviesRequest.Title);
    }
    
    [HttpGet]
    [Route("details")]
    public async Task<MovieDetailsResponse> Details([FromQuery] MovieDetailsRequest movieDetailsRequest)
    {
        string?[] options = {movieDetailsRequest.Wikipedia ? "wikipedia" : null, 
                                movieDetailsRequest.Posters ? "posters" : null};
        return await _service.Details(movieDetailsRequest.MovieId, options);
    }
}