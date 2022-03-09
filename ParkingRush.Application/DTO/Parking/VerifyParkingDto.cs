using ParkingRush.Application.DTO.Common;

namespace ParkingRush.Application.DTO;

public class VerifyParkingDto : BaseDto
{
    public bool IsVerified { get; set; }
}