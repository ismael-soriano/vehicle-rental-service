using System;
using Microsoft.EntityFrameworkCore;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    public sealed class VehicleRentalDbContext : DbContext
    {
        public VehicleRentalDbContext(DbContextOptions<VehicleRentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleRentalDbContext).Assembly);
        }
    }
}
