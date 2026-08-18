using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Output data for the Rent Vehicle Use Case.
    /// </summary>
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">The unique technical identity of the rental.</param>
        /// <param name="vehicleId">The unique technical identity of the rented vehicle.</param>
        /// <param name="customerId">The unique technical identity of the customer who rented the vehicle.</param>
        /// <param name="rentedAt">The date and time when the vehicle was rented.</param>
        public RentVehicleOutput(Guid rentalId, Guid vehicleId, Guid customerId, DateTime rentedAt)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            CustomerId = customerId;
            RentedAt = rentedAt;
        }

        /// <summary>
        /// Gets the unique technical identity of the rental.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Gets the unique technical identity of the rented vehicle.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the unique technical identity of the customer who rented the vehicle.
        /// </summary>
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the date and time when the vehicle was rented.
        /// </summary>
        public DateTime RentedAt { get; }
    }
}
