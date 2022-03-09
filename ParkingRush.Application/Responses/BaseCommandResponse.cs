namespace ParkingRush.Application.Responses;

public class BaseCommandResponse
{
    public string Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}