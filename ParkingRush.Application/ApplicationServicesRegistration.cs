using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ParkingRush.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServicesR(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}