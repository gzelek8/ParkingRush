using FluentValidation;
namespace ParkingRush.Application.DTO.Parking.Validators;

public class CreateParkingDtoValidator : AbstractValidator<CreateParkingDto>
{
    public CreateParkingDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");
        
        RuleFor(p => p.Capacity)
            .GreaterThan(0).WithMessage("{PropertyName} must be at least {ComparisionValue}")
            .LessThan(10000).WithMessage("{PropertyName} must be less than {ComparisionValue}");
        
        RuleFor(p => p.PricePerHour)
            .GreaterThan(0).WithMessage("{PropertyName} must be at least {ComparisionValue}")
            .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisionValue}");

        RuleFor(p => p.Type)
            .IsInEnum();
        
        RuleFor(p => p.Address)
            .NotNull().SetValidator(new AddressDtoValidator());
    }
}