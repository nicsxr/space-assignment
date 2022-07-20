using FluentValidation;
using MoviesWatchlist.Domain.Models.Requests;

namespace MoviesWatchlist.Domain.Models.Validation.Movies;

public class SearchMoviesRequestValidator : AbstractValidator<SearchMoviesRequest>
{
    public SearchMoviesRequestValidator()
    {
        RuleFor(m => m.Title).NotEmpty();
    }
}