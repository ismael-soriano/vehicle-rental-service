using System.Threading.Tasks;

namespace VehicleRental.Microservice.Domain.Rentals
{
    /// <summary>
    /// Defines the contract for a repository that manages rental entities.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Adds a new rental to the repository.
        /// </summary>
        /// <param name="rental">A RENTAL of a vehicle by a customer.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Add(Rental rental);

        /// <summary>
        /// Checks if a customer has an active rental in the repository.
        /// </summary>
        /// <param name="customerId">The unique technical identity of the customer who rented the vehicle.</param>
        /// <returns>A <see cref="bool"/> representing if the customer has already an active rental registered.</returns>
        Task<bool> HasActiveRentalForCustomer(CustomerId customerId);
    }
}
