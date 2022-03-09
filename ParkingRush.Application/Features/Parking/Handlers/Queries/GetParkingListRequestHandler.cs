using AutoMapper;
using MediatR;
using ParkingRush.Application.DTO;
using ParkingRush.Application.Features.Parking.Requests;
using ParkingRush.Application.Persistence.Contracts;

namespace ParkingRush.Application.Features.Parking.Handlers.Queries;

public class GetParkingListRequestHandler : IRequestHandler<GetParkingListRequest, List<ParkingDto>>
{
    private readonly IParkingRepository _parkingRepository;
    private readonly IMapper _mapper;

    public GetParkingListRequestHandler(IParkingRepository parkingRepository, IMapper mapper)
    {
        _parkingRepository = parkingRepository;
        _mapper = mapper;
    }

    public async Task<List<ParkingDto>> Handle(GetParkingListRequest request, CancellationToken cancellationToken)
    {
        var parkings = await _parkingRepository.GetAll();
        return _mapper.Map<List<ParkingDto>>(parkings);
    }
}