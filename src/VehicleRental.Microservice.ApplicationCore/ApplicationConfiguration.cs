using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Microservice.ApplicationCore.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;
using VehicleRental.Microservice.Domain.Rentals;

[assembly: CLSCompliant(false)]

namespace VehicleRental.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<CreateVehicleInput>, CreateVehicleUseCase>();
            services.AddScoped<IUseCase<ListAvailableVehiclesInput>, ListAvailableVehiclesUseCase>();
            services.AddScoped<RentalService>();
            services.AddScoped<IUseCase<RentVehicleInput>, RentVehicleUseCase>();
            return services;
        }
    }
}
