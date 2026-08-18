using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Input for the use case of returning a vehicle.
    /// </summary>
    public sealed class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the vehicle to be returned.</param>
        public ReturnVehicleInput(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }

        /// <summary>
        /// Gets the unique identifier of the vehicle to be returned.
        /// </summary>
        public Guid VehicleId { get; }
    }
}
