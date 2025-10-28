using Application.DTOs.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class GetMarketDataPricesForCertainTimeAsyncRequestValidator : AbstractValidator<GetMarketDataPricesForCertainTimeAsyncRequest>
    {
        public GetMarketDataPricesForCertainTimeAsyncRequestValidator()
        {
            RuleFor(x => x.InstrumentName)
                .NotNull()
                .WithMessage("InstrumentName не может быть пустым")
                .Must(name => string.IsNullOrEmpty(name) || !name.Any(char.IsDigit))
                .WithMessage("InstrumentName не должен содержать цифр");

            RuleFor(x => x.DateTime)
                .NotNull()
                .WithMessage("DateTime не может быть пустым")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("DateTime не может быть в будущем");
        }
    }
}