using MediatR;
using ParkingRush.Application.DTO;
using ParkingRush.Application.Responses;

namespace ParkingRush.Application.Features.Parking.Requests.Commands;

public class CreateParkingCommand : IRequest<BaseCommandResponse>
{
    public CreateParkingDto ParkingDto { get; set; }
}