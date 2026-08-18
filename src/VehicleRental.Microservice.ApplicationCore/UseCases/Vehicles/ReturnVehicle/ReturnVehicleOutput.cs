using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Output for the use case of returning a vehicle.
    /// </summary>
    public sealed class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">The unique identifier of the rental associated with the returned vehicle.</param>
        /// <param name="vehicleId">The unique identifier of the vehicle that was returned.</param>
        /// <param name="returnedAt">The date and time when the vehicle was returned.</param>
        public ReturnVehicleOutput(Guid rentalId, Guid vehicleId, DateTime returnedAt)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            ReturnedAt = returnedAt;
        }

        /// <summary>
        /// Gets the unique identifier of the rental associated with the returned vehicle.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Gets the unique identifier of the vehicle that was returned.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the date and time when the vehicle was returned.
        /// </summary>
        public DateTime ReturnedAt { get; }
    }
}
