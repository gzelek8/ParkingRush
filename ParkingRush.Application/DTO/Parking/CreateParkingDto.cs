namespace ParkingRush.Application.DTO;

public class CreateParkingDto
{
    public string Name { get; set; }
    public AddressDto Address { get; set; }
    public int? Capacity { get; set; }
    public decimal? PricePerHour { get; set; }
    public TypeDto? Type { get; set; }
}