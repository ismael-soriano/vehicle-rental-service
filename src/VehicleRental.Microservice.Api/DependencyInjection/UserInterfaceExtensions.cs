using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles;
using VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;

namespace VehicleRental.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(sp => sp.GetRequiredService<CreateVehiclePresenter>());
            services.AddScoped<ListAvailableVehiclesPresenter>();
            services.AddScoped<IListAvailableVehiclesOutputPort>(sp => sp.GetRequiredService<ListAvailableVehiclesPresenter>());
            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(sp => sp.GetRequiredService<RentVehiclePresenter>());
            return services;
        }
    }
}
