using FluentValidation;
using MoviesWatchlist.Domain.Models.Requests.WatchList;

namespace MoviesWatchlist.Domain.Models.Validation.WatchList;

public class GetUserMoviesRequestValidator : AbstractValidator<GetUserMoviesRequest>
{
    public GetUserMoviesRequestValidator()
    {
        RuleFor(m => m.UserId).NotEmpty();
    }
}