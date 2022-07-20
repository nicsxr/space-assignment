using FluentValidation;
using MoviesWatchlist.Domain.Models.Requests;

namespace MoviesWatchlist.Domain.Models.Validation.Movies;

public class MovieDetailsRequestValidator : AbstractValidator<MovieDetailsRequest>
{
    public MovieDetailsRequestValidator()
    {
        RuleFor(m => m.MovieId).NotEmpty();
        RuleFor(m => m.MovieId).MinimumLength(3);
        // RuleFor(m => m.MovieId).NotEmpty().Must(str => str.StartsWith("tt"));
    }
}