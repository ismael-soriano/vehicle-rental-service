using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Output message for the create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">The unique technical identity of the vehicle.</param>
        /// <param name="licensePlate">The license plate text.</param>
        public CreateVehicleOutput(Guid vehicleId, string licensePlate)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
        }

        /// <summary>
        /// Gets the unique technical identity of the vehicle.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the license plate that uniquely identifies a vehicle.
        /// </summary>
        public string LicensePlate { get; }
    }
}
