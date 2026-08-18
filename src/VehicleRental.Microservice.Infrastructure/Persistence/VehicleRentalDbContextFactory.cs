using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// Creates <see cref="VehicleRentalDbContext"/> instances at design time (e.g. for
    /// <c>dotnet ef migrations</c>), without requiring the whole application composition
    /// root (Host <c>Program.cs</c>) to build successfully.
    /// </summary>
    public sealed class VehicleRentalDbContextFactory : IDesignTimeDbContextFactory<VehicleRentalDbContext>
    {
        /// <summary>
        /// Environment variable name following ASP.NET Core's configuration convention
        /// (<c>Section__Key</c>) for overriding <c>ConnectionStrings:VehicleRental</c>.
        /// </summary>
        private const string ConnectionStringEnvironmentVariable = "ConnectionStrings__VehicleRental";

        /// <summary>
        /// Mirrors the default value in <c>Host/appsettings.Development.json</c>. Override it
        /// at design time via the <see cref="ConnectionStringEnvironmentVariable"/> environment
        /// variable instead of editing this constant, to avoid the two values drifting apart.
        /// </summary>
        private const string FallbackConnectionString =
            "Host=localhost;Port=5432;Database=vehiclerental;Username=vehiclerental;Password=vehiclerental";

        /// <inheritdoc/>
        public VehicleRentalDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable)
                ?? FallbackConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<VehicleRentalDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new VehicleRentalDbContext(optionsBuilder.Options);
        }
    }
}
