using ParkingRush.Application.DTO.Common;

namespace ParkingRush.Application.DTO;

public class ParkingDto : BaseDto
{
    public string Name { get; set; }
    public AddressDto Address { get; set; }
    public int? Capacity { get; set; }
    public decimal? PricePerHour { get; set; }
    public int? FreeSpaces { get; set; }
    public TypeDto? Type { get; set; }
}