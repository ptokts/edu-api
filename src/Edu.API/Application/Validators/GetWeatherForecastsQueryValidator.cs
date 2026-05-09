using Edu.API.Application.Queries;
using FluentValidation;

namespace Edu.API.Application.Validators;

/// <summary>
/// Validator for the get weather forecasts query.
/// </summary>
public sealed class GetWeatherForecastsQueryValidator : AbstractValidator<GetWeatherForecastsQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetWeatherForecastsQueryValidator"/> class.
    /// </summary>
    public GetWeatherForecastsQueryValidator()
    {
        RuleFor(x => x.Location)
            .MaximumLength(100)
            .WithMessage("Location must not exceed 100 characters.");

        RuleFor(x => x)
            .Custom((query, context) =>
            {
                if (query.StartDate.HasValue && query.EndDate.HasValue && query.StartDate > query.EndDate)
                {
                    context.AddFailure("StartDate must be less than or equal to EndDate.");
                }
            });
    }
}
