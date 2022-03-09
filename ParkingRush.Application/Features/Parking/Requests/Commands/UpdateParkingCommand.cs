using MediatR;
using ParkingRush.Application.DTO;

namespace ParkingRush.Application.Features.Parking.Requests.Commands;

public class UpdateParkingCommand : IRequest<Unit>
{
    public string Id { get; set; }
    public UpdateParkingDto ParkingDto { get; set; }

    public VerifyParkingDto VerifyParkingDto { get; set; }
}