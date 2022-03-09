namespace ParkingRush.Application.DTO;

public class AddressDto
{
    public string City { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public PointDto Location { get; set; }
}