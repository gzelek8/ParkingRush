using MediatR;
using ParkingRush.Application.DTO;

namespace ParkingRush.Application.Features.Parking.Requests;

public class GetParkingDetailsRequest : IRequest<ParkingDto>
{
    public string Id { get; set; }
}