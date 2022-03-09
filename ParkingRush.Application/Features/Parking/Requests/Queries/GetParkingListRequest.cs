using MediatR;
using ParkingRush.Application.DTO;

namespace ParkingRush.Application.Features.Parking.Requests;

public class GetParkingListRequest : IRequest<List<ParkingDto>>
{
    
}