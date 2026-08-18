using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleRental.Microservice.Domain;
using VehicleRental.Microservice.Domain.Interfaces;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    public sealed class UnitOfWork(VehicleRentalDbContext context) : IUnitOfWork, IDisposable
    {
        private bool _disposed;

        public async Task<int> Save()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyConflictException(
                    "The record was modified by another request. Please retry.", ex);
            }
        }

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
