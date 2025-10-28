using Application.Models.DTOs_for_requests;
using FluentValidation;

namespace Application.Validators
{
    public class DataMarketRequestValidator : AbstractValidator<DataMarketRequest>
    {
        public DataMarketRequestValidator()
        {
            RuleFor(x => x.InstrumentCode)
                .NotNull()
                .WithMessage("InstrumentCode не может быть пустым")
                .Must(name => string.IsNullOrEmpty(name) || !name.Any(char.IsDigit))
                .WithMessage("InstrumentCode не должен содержать цифр");

            RuleFor(x => x.DaysCount)
                .NotNull()
                .WithMessage("DaysCount не может быть пустым")
                .Must(value => !value.ToString().Any(char.IsLetter))
                .WithMessage("DaysCount не должен содержать букв");
        }
    }
}