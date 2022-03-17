using MongoDB.Driver;
using ParkingRush.Application.Contracts.Persistence;

namespace ParkingRush.Persistance.Data.MongoDb;

public class MongoBaseRepository<TModel> : IGenericRepository<TModel> where TModel : class
{
    protected IMongoCollection<TModel> MongoCollection { get; }

    public MongoBaseRepository(MongoDbConnectionParams mongoDbConnectionParams)
    {
        if (mongoDbConnectionParams == null)
        {
            throw new ArgumentNullException();
        }

        var client = new MongoClient(mongoDbConnectionParams.ConnectionString);
        var dataBase = client.GetDatabase(mongoDbConnectionParams.DataBaseName);
        MongoCollection = dataBase.GetCollection<TModel>(mongoDbConnectionParams.CollectionName);
    }

    public Task<TModel> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<TModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<TModel> Add(TModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<TModel> Update(TModel entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TModel entity)
    {
        throw new NotImplementedException();
    }
}