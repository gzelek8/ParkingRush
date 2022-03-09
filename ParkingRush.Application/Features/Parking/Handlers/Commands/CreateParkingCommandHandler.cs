using AutoMapper;
using MediatR;
using ParkingRush.Application.DTO.Parking.Validators;
using ParkingRush.Application.Exceptions;
using ParkingRush.Application.Features.Parking.Requests.Commands;
using ParkingRush.Application.Persistence.Contracts;
using ParkingRush.Application.Responses;

namespace ParkingRush.Application.Features.Parking.Handlers.Commands;

public class CreateParkingCommandHandler : IRequestHandler<CreateParkingCommand, BaseCommandResponse>
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IMapper _mapper;

    public CreateParkingCommandHandler(IParkingRepository parkingRepository, IMapper mapper)
    {
        _parkingRepository = parkingRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateParkingCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateParkingDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ParkingDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        var parking = _mapper.Map<Domain.Parking>(request.ParkingDto);
        parking = await _parkingRepository.Add(parking);
        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = parking.Id;
        return response;
    }
}