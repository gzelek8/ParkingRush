using FluentValidation;

namespace ParkingRush.Application.DTO.Parking.Validators;

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(p => p.City)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");
        RuleFor(p => p.Street)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");
        RuleFor(p => p.ZipCode)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");
        
        RuleFor(p => p.Location)
            .NotNull().SetValidator(new PointDtoValidator());
    }
}