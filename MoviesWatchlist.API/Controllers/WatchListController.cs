using Microsoft.AspNetCore.Mvc;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Domain.Models;
using MoviesWatchlist.Domain.Models.Requests.WatchList;

namespace MoviesWatchlist.API.Controllers;

[ApiController]
[Route("api/watchlist")]
public class WatchListController : ControllerBase
{
    private readonly ILogger<WatchListController> _logger;
    private readonly IWatchListService _service;

    public WatchListController(ILogger<WatchListController> logger, IWatchListService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    public async Task<bool> AddMovie([FromBody] AddMovieRequest addMovieRequest)
    {
        return await _service.AddMovie(addMovieRequest.UserId, addMovieRequest.MovieId);
    }
    
    [HttpGet]
    public async Task<List<MovieItem>> GetUserMovies([FromQuery] GetUserMoviesRequest getUserMoviesRequest)
    {
        return await _service.GetWatchlistMovies(getUserMoviesRequest.UserId);
    }
    
    [HttpPatch]
    [Route("markaswatched")]
    public async Task<bool> MarkAsWatched([FromBody] MarkAsWatchedRequest markAsWatchedRequest)
    {
        return await _service.MarkAsWatched(markAsWatchedRequest.UserId, markAsWatchedRequest.MovieId);
    }
}