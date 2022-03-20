using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingRush.Application.DTO;
using ParkingRush.Application.Features.Parking.Requests;
using ParkingRush.Application.Features.Parking.Requests.Commands;

namespace ParkingRush.Api.Controllers;

[Route("api/parkings")]
[ApiController]
public class ParkingController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParkingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ParkingDto>>> Get()
    {
        var parkings = await _mediator.Send(new GetParkingListRequest());
        return Ok(parkings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ParkingDto>> GetById(string id)
    {
        var parking = await _mediator.Send(new GetParkingDetailsRequest {Id = id});
        return Ok(parking);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] CreateParkingDto parkingDto)
    {
        var command = new CreateParkingCommand {ParkingDto = parkingDto};
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromBody] UpdateParkingDto parkingDto)
    {
        var command = new UpdateParkingCommand {ParkingDto = parkingDto};
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var command = new DeleteParkingCommand {Id = id};
        await _mediator.Send(command);
        return NoContent();
    }
}