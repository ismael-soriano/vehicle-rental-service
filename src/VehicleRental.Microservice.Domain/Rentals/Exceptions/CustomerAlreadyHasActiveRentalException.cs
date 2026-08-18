using System;
using System.Diagnostics.CodeAnalysis;

namespace VehicleRental.Microservice.Domain.Rentals.Exceptions
{
    /// <summary>
    /// Thrown when a customer already has an active rental and attempts to create a new rental.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class CustomerAlreadyHasActiveRentalException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyHasActiveRentalException"/> class.
        /// </summary>
        public CustomerAlreadyHasActiveRentalException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyHasActiveRentalException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public CustomerAlreadyHasActiveRentalException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAlreadyHasActiveRentalException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public CustomerAlreadyHasActiveRentalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
