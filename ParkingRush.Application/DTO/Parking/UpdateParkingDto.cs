using ParkingRush.Application.DTO.Common;

namespace ParkingRush.Application.DTO;

public class UpdateParkingDto : BaseDto
{
    public string Name { get; set; }
    public decimal? PricePerHour { get; set; }
}