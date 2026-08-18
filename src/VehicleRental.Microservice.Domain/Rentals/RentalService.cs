using System;
using System.Threading.Tasks;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.Domain.Rentals
{
    /// <summary>
    /// Represents a service that handles the rental process of vehicles by customers.
    /// </summary>
    public sealed class RentalService
    {
        private readonly IRentalRepository _rentalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalService"/> class with the specified rental repository.
        /// </summary>
        /// <param name="rentalRepository">Provides persistence capabilities for the <see cref="Rental"/> aggregate.</param>
        /// <exception cref="ArgumentNullException">Throws if any of the parameters is null.</exception>
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
        }

        /// <summary>
        /// Rents a vehicle to a customer at a specified date and time, ensuring that the customer does not already have an active rental.
        /// </summary>
        /// <param name="vehicle">Vehicle that belongs to the renting fleet.</param>
        /// <param name="customerId">The unique technical identity of the customer who rented the vehicle.</param>
        /// <param name="rentedAt">The date and time when the vehicle was returned, or <c>null</c> if the vehicle has not been returned yet.</param>
        /// <returns>A newly created <see cref="Rental"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Throws if the vehicle property its null.</exception>
        /// <exception cref="CustomerAlreadyHasActiveRentalException">Throws if the customer has already an active rental.</exception>
        public async Task<Rental> Rent(Vehicle vehicle, CustomerId customerId, DateTime rentedAt)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var hasActiveRental = await _rentalRepository.HasActiveRentalForCustomer(customerId);
            if (hasActiveRental)
            {
                throw new CustomerAlreadyHasActiveRentalException(
                    $"Customer {customerId} already has an active rental.");
            }

            vehicle.Rent();

            return Rental.Create(vehicle.Id, customerId, rentedAt);
        }
    }
}
