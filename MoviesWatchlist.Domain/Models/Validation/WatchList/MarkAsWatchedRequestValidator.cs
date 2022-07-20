using FluentValidation;
using MoviesWatchlist.Domain.Models.Requests.WatchList;

namespace MoviesWatchlist.Domain.Models.Validation.WatchList;

public class MarkAsWatchedRequestValidator : AbstractValidator<MarkAsWatchedRequest>
{
    public MarkAsWatchedRequestValidator()
    {
        RuleFor(m => m.MovieId).NotEmpty();
        RuleFor(m => m.MovieId).MinimumLength(3);

        RuleFor(m => m.UserId).NotEmpty();
    }
}