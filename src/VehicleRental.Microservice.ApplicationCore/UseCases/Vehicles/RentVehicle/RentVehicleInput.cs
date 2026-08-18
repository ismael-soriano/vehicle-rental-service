using System;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Input data for the Rent Vehicle Use Case.
    /// </summary>
    public sealed class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The unique technical identity of the vehicle to be rented.</param>
        /// <param name="customerId">The unique technical identity of the customer who is renting the vehicle.</param>
        public RentVehicleInput(Guid vehicleId, Guid customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        /// <summary>
        /// Gets the unique technical identity of the vehicle to be rented.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the unique technical identity of the customer who is renting the vehicle.
        /// </summary>
        public Guid CustomerId { get; }
    }
}
