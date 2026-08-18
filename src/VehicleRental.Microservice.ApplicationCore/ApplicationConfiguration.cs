using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Microservice.ApplicationCore.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles;

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
            return services;
        }
    }
}
