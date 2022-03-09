using AutoMapper;
using MediatR;
using ParkingRush.Application.DTO;
using ParkingRush.Application.Features.Parking.Requests;
using ParkingRush.Application.Persistence.Contracts;

namespace ParkingRush.Application.Features.Parking.Handlers.Queries;

public class GetParkingDetailRequestHandler : IRequestHandler<GetParkingDetailsRequest, ParkingDto>
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IMapper _mapper;

    public GetParkingDetailRequestHandler(IParkingRepository parkingRepository, IMapper mapper)
    {
        _parkingRepository = parkingRepository;
        _mapper = mapper;
    }

    public async Task<ParkingDto> Handle(GetParkingDetailsRequest request, CancellationToken cancellationToken)
    {
        var parking = await _parkingRepository.GetById(request.Id);
        return _mapper.Map<ParkingDto>(parking);
    }
}