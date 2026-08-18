using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Microservice.Api.Vehicles;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles;

namespace VehicleRental.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(sp => sp.GetRequiredService<CreateVehiclePresenter>());
            return services;
        }
    }
}
