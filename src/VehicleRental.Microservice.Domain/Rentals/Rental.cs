using System;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.Domain.Rentals
{
    /// <summary>
    /// Represents a rental of a vehicle by a customer.
    /// </summary>
    public sealed class Rental
    {
        private Rental(RentalId id, VehicleId vehicleId, CustomerId customerId, DateTime rentedAt, DateTime? returnedAt)
        {
            Id = id;
            VehicleId = vehicleId;
            CustomerId = customerId;
            RentedAt = rentedAt;
            ReturnedAt = returnedAt;
        }

        /// <summary>
        /// Gets the unique technical identity of the rental.
        /// </summary>
        public RentalId Id { get; }

        /// <summary>
        /// Gets the unique technical identity of the rented vehicle.
        /// </summary>
        public VehicleId VehicleId { get; }

        /// <summary>
        /// Gets the unique technical identity of the customer who rented the vehicle.
        /// </summary>
        public CustomerId CustomerId { get; }

        /// <summary>
        /// Gets the date and time when the vehicle was rented.
        /// </summary>
        public DateTime RentedAt { get; }

        /// <summary>
        /// Gets the date and time when the vehicle was returned, or <c>null</c> if the vehicle has not been returned yet.
        /// </summary>
        public DateTime? ReturnedAt { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the rental is currently active (i.e., the vehicle has not been returned yet).
        /// </summary>
        public bool IsActive => ReturnedAt is null;

        /// <summary>
        /// Creates a new rental instance with the specified vehicle ID, customer ID, and rented date.
        /// </summary>
        /// <param name="vehicleId">The unique technical identity of the rented vehicle.</param>
        /// <param name="customerId">The unique technical identity of the customer who rented the vehicle.</param>
        /// <param name="rentedAt">The date and time when the vehicle was returned, or <c>null</c> if the vehicle has not been returned yet.</param>
        /// <returns>A new <see cref="Rental"/> with the current datetime for the rental.</returns>
        public static Rental Create(VehicleId vehicleId, CustomerId customerId, DateTime rentedAt)
        {
            return new Rental(RentalId.New(), vehicleId, customerId, rentedAt, returnedAt: null);
        }

        /// <summary>
        /// Marks the rental as returned.
        /// </summary>
        /// <param name="returnedAt">The date and time when the vehicle was returned.</param>
        /// <exception cref="RentalAlreadyClosedException">Throws if the rental has already been returned.</exception>
        public void Return(DateTime returnedAt)
        {
            if (ReturnedAt is not null)
            {
                throw new RentalAlreadyClosedException($"Rental {Id} has already been returned.");
            }

            ReturnedAt = returnedAt;
        }
    }
}
