using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingRush.Applicatio.Contracts.Persistence;
using ParkingRush.Persistance.Data.MongoDb;

namespace ParkingRush.Persistance;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        MongoDbModelRegistrar.RegisterAllCaseConvention();
        MongoDbModelRegistrar.RegisterModels();

        services.AddScoped<IParkingRepository>(x =>
        {
            var cs = configuration.GetConnectionString("MongoDbConnectionStringKey");
            // var databaseName =
            //     configuration.GetConnectionString("MongoDbConnectionStringKey"); // toDo remember to change GetValue
            var mongoConnectionParams = new MongoDbConnectionParams(cs, "parking", "parking");
            return new MongoParkingRepository(mongoConnectionParams);
        });


        return services;
    }
}