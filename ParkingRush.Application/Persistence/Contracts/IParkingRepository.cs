using ParkingRush.Domain;

namespace ParkingRush.Application.Persistence.Contracts;

public interface IParkingRepository : IGenericRepository<Parking>
{
    Task Verify(Parking entity, bool isVerified);

}