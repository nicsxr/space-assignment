using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoviesWatchlist.Domain.Abstractions.Infrastructure;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.API.Controllers;

[ApiController]
[Route("api/error")]
public class ErrorController : Controller
{
    // private readonly ILogger<WatchListController> _logger;
    // private readonly IMovieApiService _service;
    //
    // public MoviesController(ILogger<WatchListController> logger, IMovieApiService service)
    // {
    //     _logger = logger;
    //     _service = service;
    // }

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return NotFound();
        }

        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        return Problem(
            // detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message);
    }

}