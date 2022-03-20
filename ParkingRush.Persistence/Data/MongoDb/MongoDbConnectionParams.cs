namespace ParkingRush.Persistance.Data.MongoDb;

public class MongoDbConnectionParams
{
    public MongoDbConnectionParams(string connectionString, string dataBaseName, string collectionName)
    {
        ConnectionString = connectionString;
        DataBaseName = dataBaseName;
        CollectionName = collectionName;
    }

    public string ConnectionString { get; set; }
    public string DataBaseName { get; set; }
    public string CollectionName { get; set; }
}