using ParkingRush.Domain.Common;

namespace ParkingRush.Domain;

public class Parking : BaseDomainEntity
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public int? Capacity { get; set; }
    public decimal? PricePerHour { get; set; }
    public Type? Type { get; set; }
    public bool? IsVerified { get; set; }
    public int? FreeSpaces { get; set; }
}