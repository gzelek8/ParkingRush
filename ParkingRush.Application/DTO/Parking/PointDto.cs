namespace ParkingRush.Application.DTO;

public class PointDto
{ 
    public string Type { get; set; }
    public List<long>? Coordinates { get; set; }
}