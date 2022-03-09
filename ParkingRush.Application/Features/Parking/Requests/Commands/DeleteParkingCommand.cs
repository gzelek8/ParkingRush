using MediatR;

namespace ParkingRush.Application.Features.Parking.Requests.Commands;

public class DeleteParkingCommand : IRequest
{
    public string Id { get; set; }
}