using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Input message for the create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="licensePlate">The license plate text.</param>
        /// <param name="manufactureDate">The manufacture date.</param>
        public CreateVehicleInput(string licensePlate, DateOnly manufactureDate)
        {
            LicensePlate = licensePlate;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets the license plate that uniquely identifies a vehicle.
        /// </summary>
        public string LicensePlate { get; }

        /// <summary>
        /// Gets the Manufacture Date of the vehicle.
        /// </summary>
        public DateOnly ManufactureDate { get; }
    }
}
