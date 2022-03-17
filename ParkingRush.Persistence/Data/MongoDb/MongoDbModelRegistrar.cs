using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using ParkingRush.Domain;
using ParkingRush.Domain.Common;
using Type = System.Type;

namespace ParkingRush.Persistance.Data.MongoDb;

public class MongoDbModelRegistrar
{
    private static bool _modelRegistered;
    private static readonly object SyncRoot = new object();

    public static void RegisterModels()
    {
        lock (SyncRoot)
        {
            if (!_modelRegistered)
            {
                RegisterEntity<Parking>();
                RegisterValueObject<Address>();
                RegisterValueObject<Point>();
                RegisterValueObject<Type>();
            }
        }
    }

    private static void RegisterEntity<TModel>() where TModel : BaseDomainEntity
    {
        BsonClassMap.RegisterClassMap<TModel>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty("Id").SetIdGenerator(StringObjectIdGenerator.Instance);
        });
    }

    private static void RegisterValueObject<TModel>()
    {
        BsonClassMap.RegisterClassMap<TModel>();
    }

    private static void RegisterCamelCaseConvention()
    {
        var conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
        ConventionRegistry.Register(nameof(CamelCaseElementNameConvention), conventionPack, type => true);
    }

    private static void RegisterPrivateSetters()
    {
        var conventionPack = new ConventionPack {new ImmutableTypeClassMapConvention()};
        ConventionRegistry.Register(nameof(ImmutableTypeClassMapConvention), conventionPack, type => true);
    }

    private static void RegisterIgnoreExtraFields()
    {
        var conventionPack = new ConventionPack {new IgnoreExtraElementsConvention(true)};
        ConventionRegistry.Register(nameof(IgnoreExtraElementsConvention), conventionPack, type => true);
    }

    public static void RegisterAllCaseConvention()
    {
        RegisterCamelCaseConvention();
        RegisterPrivateSetters();
        RegisterIgnoreExtraFields();
    }
}