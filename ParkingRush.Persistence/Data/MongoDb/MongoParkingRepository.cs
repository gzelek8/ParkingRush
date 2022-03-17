using ParkingRush.Applicatio.Contracts.Persistence;
using ParkingRush.Domain;

namespace ParkingRush.Persistance.Data.MongoDb;

public class MongoParkingRepository : MongoBaseRepository<Parking>, IParkingRepository
{
    public MongoParkingRepository(MongoDbConnectionParams mongoDbConnectionParams) : base(mongoDbConnectionParams)
    {
    }

    public Task Verify(Parking entity, bool isVerified)
    {
        throw new NotImplementedException();
    }

    public Task<List<Parking>> FindByRadius(double radius)
    {
        throw new NotImplementedException();
    }
}