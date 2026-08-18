using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Represents a single available vehicle in the output of the list available vehicles use case.
    /// </summary>
    public sealed class AvailableVehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableVehicle"/> class.
        /// </summary>
        /// <param name="vehicleId">The unique technical identity of a vehicle.</param>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
        public AvailableVehicle(Guid vehicleId, string licensePlate, DateOnly manufactureDate)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets the unique identifier of the vehicle.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        public DateOnly ManufactureDate { get; }
    }
}
