using FluentValidation;
using MoviesWatchlist.Domain.Models.Requests.WatchList;

namespace MoviesWatchlist.Domain.Models.Validation.WatchList;

public class AddMovieRequestValidator : AbstractValidator<AddMovieRequest>
{
    public AddMovieRequestValidator()
    {
        RuleFor(m => m.MovieId).NotEmpty();
        RuleFor(m => m.MovieId).MinimumLength(3);

        RuleFor(m => m.UserId).NotEmpty();
    }
}