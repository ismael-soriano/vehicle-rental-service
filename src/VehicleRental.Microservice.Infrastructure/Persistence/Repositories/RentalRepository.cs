using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleRental.Microservice.Domain.Rentals;
using VehicleRental.Microservice.Domain.Rentals.ValueObjects;
using VehicleRental.Microservice.Domain.Vehicles.ValueObjects;

namespace VehicleRental.Microservice.Infrastructure.Persistence.Repositories
{
    public sealed class RentalRepository(VehicleRentalDbContext context) : IRentalRepository
    {
        public async Task Add(Rental rental) => await context.Rentals.AddAsync(rental);

        public async Task<bool> HasActiveRentalForCustomer(CustomerId customerId) =>
            await context.Rentals.AnyAsync(r => r.CustomerId == customerId && r.ReturnedAt == null);

        public async Task<Rental> GetActiveByVehicle(VehicleId vehicleId) =>
            await context.Rentals.SingleOrDefaultAsync(r => r.VehicleId == vehicleId && r.ReturnedAt == null);
    }
}
