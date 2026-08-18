using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Microservice.Domain.Interfaces;
using VehicleRental.Microservice.Domain.Rentals;
using VehicleRental.Microservice.Domain.Vehicles;
using VehicleRental.Microservice.Infrastructure.Persistence;

namespace VehicleRental.Microservice.Infrastructure
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<VehicleRentalDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
