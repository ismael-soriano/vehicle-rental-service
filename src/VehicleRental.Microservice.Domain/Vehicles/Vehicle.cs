using System;

namespace VehicleRental.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents a vehicle that belongs to the rental fleet.
    /// </summary>
    public sealed class Vehicle
    {
        /// <summary>
        /// The maximum age, in years, a vehicle can have to be part of the fleet.
        /// </summary>
        private const int MaxFleetAgeInYears = 5;

        private Vehicle(VehicleId id, LicensePlate licensePlate, ManufactureDate manufactureDate, VehicleStatus status)
        {
            Id = id;
            LicensePlate = licensePlate;
            ManufactureDate = manufactureDate;
            Status = status;
        }

        /// <summary>
        /// Gets the unique identifier of the vehicle.
        /// </summary>
        public VehicleId Id { get; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        public LicensePlate LicensePlate { get; }

        /// <summary>
        /// Gets the manufacture date of the vehicle.
        /// </summary>
        public ManufactureDate ManufactureDate { get; }

        /// <summary>
        /// Gets the current availability status of the vehicle.
        /// </summary>
        public VehicleStatus Status { get; private set; }

        /// <summary>
        /// Creates a new <see cref="Vehicle"/> to be added to the fleet.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
        /// <param name="today">The current date, resolved by the caller.</param>
        /// <returns>A new <see cref="Vehicle"/> in <see cref="VehicleStatus.Available"/> status.</returns>
        public static Vehicle Create(LicensePlate licensePlate, ManufactureDate manufactureDate, DateOnly today)
        {
            if (manufactureDate.AgeInYears(today) > MaxFleetAgeInYears)
            {
                throw new VehicleTooOldException(
                    $"Vehicles manufactured more than {MaxFleetAgeInYears} years ago cannot join the fleet.");
            }

            return new Vehicle(VehicleId.New(), licensePlate, manufactureDate, VehicleStatus.Available);
        }
    }
}
