using FluentValidation;

namespace ParkingRush.Application.DTO.Parking.Validators;

public class PointDtoValidator : AbstractValidator<PointDto>
{
    public PointDtoValidator()
    {
        RuleFor(p => p.Type)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .Equal("Point").WithMessage("{PropertyName} must be equal \"Point\"");
        RuleFor(p => p.Coordinates![0])
            .InclusiveBetween(-180, 180)
            .WithMessage("Invalid longitude value");
        RuleFor(p => p.Coordinates![1])
            .InclusiveBetween(-90, 90)
            .WithMessage("Invalid latitude value");
    }
}