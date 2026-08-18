using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    public sealed class VehicleRepository(VehicleRentalDbContext context) : IVehicleRepository
    {
        public async Task Add(Vehicle vehicle)
        {
            await context.Vehicles.AddAsync(vehicle);
        }

        public async Task<Vehicle> GetById(VehicleId id)
        {
            return await context.Vehicles.SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}
