using Microsoft.AspNetCore.Mvc;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Domain.Models;
using MoviesWatchlist.Domain.Models.Requests.WatchList;
using MoviesWatchlist.EmailService;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesWatchlist.API.Controllers;

[ApiController]
[Route("api/watchlist")]
public class WatchListController : ControllerBase
{
    private readonly ILogger<WatchListController> _logger;
    private readonly IWatchListService _service;
    private readonly IEmailSender _emailSender;

    public WatchListController(ILogger<WatchListController> logger, IWatchListService service, IEmailSender emailSender)
    {
        _logger = logger;
        _service = service;
        _emailSender = emailSender;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Add movie to user's watchlist.", Description = "Add movie to user's watchlist.")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<bool> AddMovie([FromBody] AddMovieRequest addMovieRequest)
    {
        return await _service.AddMovie(addMovieRequest.UserId, addMovieRequest.MovieId);
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "List all of user's movies.", Description = "List all movies added to user's watchlist.")]
    [ProducesResponseType(typeof(MovieItem), 200)]
    public async Task<List<MovieItem>> GetUserMovies([FromQuery] GetUserMoviesRequest getUserMoviesRequest)
    {
        return await _service.GetWatchlistMovies(getUserMoviesRequest.UserId);
    }
    
    [HttpGet]
    [Route("unwatched")]
    [SwaggerOperation(Summary = "List all of user's unwatched movies.", Description = "List user's unwatched movies.")]
    [ProducesResponseType(typeof(MovieItem), 200)]
    public async Task<List<MovieItem>> GetUnwatchedMovies([FromQuery] GetUserMoviesRequest getUserMoviesRequest)
    {
        return await _service.GetUnwatchedMovies(getUserMoviesRequest.UserId);
    }
    
    [HttpPatch]
    [Route("markaswatched")]
    [SwaggerOperation(Summary = "Mark movie as watched.", Description = "Mark user's movie as watched.")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<bool> MarkAsWatched([FromBody] MarkAsWatchedRequest markAsWatchedRequest)
    {
        return await _service.MarkAsWatched(markAsWatchedRequest.UserId, markAsWatchedRequest.MovieId);
    }
}