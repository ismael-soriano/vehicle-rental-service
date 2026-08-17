using Microsoft.Extensions.DependencyInjection;

namespace VehicleRental.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            return services;
        }
    }
}
