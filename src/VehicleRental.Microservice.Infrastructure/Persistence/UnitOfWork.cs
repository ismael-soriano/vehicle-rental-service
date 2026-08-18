using System;
using System.Threading.Tasks;
using VehicleRental.Microservice.Domain.Interfaces;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    public sealed class UnitOfWork(VehicleRentalDbContext context) : IUnitOfWork, IDisposable
    {
        private bool _disposed;

        public async Task<int> Save() => await context.SaveChangesAsync();

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            context.Dispose();
            _disposed = true;
        }
    }
}
