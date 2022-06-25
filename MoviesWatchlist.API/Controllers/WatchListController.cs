using Microsoft.AspNetCore.Mvc;
using MoviesWatchlist.Domain.Abstractions.Services;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WatchListController : ControllerBase
{
    private readonly ILogger<WatchListController> _logger;
    private readonly IWatchListService _service;

    public WatchListController(ILogger<WatchListController> logger, IWatchListService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost(Name = "add")]
    public async Task<MovieItem> AddMovie(int userId, string movieId)
    {
        return await _service.AddMovie(userId, movieId);
    }
}