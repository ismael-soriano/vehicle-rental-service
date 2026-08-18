using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleRental.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Provides persistence capabilities for the <see cref="Vehicle"/> aggregate.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a new vehicle to the fleet.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Add(Vehicle vehicle);

        /// <summary>
        /// Gets a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>The vehicle, or <see langword="null"/> if it does not exist.</returns>
        Task<Vehicle> GetById(VehicleId id);

        /// <summary>
        /// Gets all available vehicles in the fleet.
        /// </summary>
        /// <returns>The collection of available vehicles.</returns>
        Task<IReadOnlyCollection<Vehicle>> GetAvailable();
    }
}
