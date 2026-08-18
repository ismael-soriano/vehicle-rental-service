using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleRental.Microservice.Domain.Rentals;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    public sealed class RentalRepository(VehicleRentalDbContext context) : IRentalRepository
    {
        public async Task Add(Rental rental) => await context.Rentals.AddAsync(rental);

        public async Task<bool> HasActiveRentalForCustomer(CustomerId customerId) =>
            await context.Rentals.AnyAsync(r => r.CustomerId == customerId && r.ReturnedAt == null);
    }
}
