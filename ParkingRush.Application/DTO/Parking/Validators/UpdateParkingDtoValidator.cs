using FluentValidation;

namespace ParkingRush.Application.DTO.Parking.Validators;

public class UpdateParkingDtoValidator : AbstractValidator<UpdateParkingDto>
{
    public UpdateParkingDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");

        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required");

        RuleFor(p => p.PricePerHour)
            .GreaterThan(0).WithMessage("{PropertyName} must be at least {ComparisionValue}")
            .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisionValue}");
    }
}