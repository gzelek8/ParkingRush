using ParkingRush.Application.Contracts.Persistence;
using ParkingRush.Domain;

namespace ParkingRush.Applicatio.Contracts.Persistence;

public interface IParkingRepository : IGenericRepository<Parking>
{
    Task Verify(Parking entity, bool isVerified);

    Task<List<Parking>> FindByRadius(double radius);
}