using AutoMapper;
using MediatR;
using ParkingRush.Applicatio.Contracts.Persistence;
using ParkingRush.Application.DTO.Parking.Validators;
using ParkingRush.Application.Exceptions;
using ParkingRush.Application.Features.Parking.Requests.Commands;

namespace ParkingRush.Application.Features.Parking.Handlers.Commands;

public class UpdateParkingCommandHandler : IRequestHandler<UpdateParkingCommand, Unit>
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IMapper _mapper;

    public UpdateParkingCommandHandler(IParkingRepository parkingRepository, IMapper mapper)
    {
        _parkingRepository = parkingRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateParkingCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateParkingDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ParkingDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        var parking = await _parkingRepository.GetById(request.Id);
        if (request.ParkingDto != null)
        {
            _mapper.Map(request.ParkingDto, parking);
            await _parkingRepository.Update(parking);
        }
        else if (request.VerifyParkingDto != null)
        {
            await _parkingRepository.Verify(parking, request.VerifyParkingDto.IsVerified);
        }

        return Unit.Value;
    }
}