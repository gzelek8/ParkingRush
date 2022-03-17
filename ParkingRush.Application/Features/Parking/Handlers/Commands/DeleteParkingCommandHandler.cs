using AutoMapper;
using MediatR;
using ParkingRush.Applicatio.Contracts.Persistence;
using ParkingRush.Application.Exceptions;
using ParkingRush.Application.Features.Parking.Requests.Commands;

namespace ParkingRush.Application.Features.Parking.Handlers.Commands;

public class DeleteParkingCommandHandler : IRequestHandler<DeleteParkingCommand>
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IMapper _mapper;

    public DeleteParkingCommandHandler(IParkingRepository parkingRepository, IMapper mapper)
    {
        _parkingRepository = parkingRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
    {
        var parking = await _parkingRepository.GetById(request.Id);
        if (parking == null)
        {
            throw new NotFoundException(nameof(Domain.Parking), request.Id);
        }

        await _parkingRepository.Delete(parking);
        return Unit.Value;
    }
}