using System;
using System.Diagnostics.CodeAnalysis;

namespace VehicleRental.Microservice.Domain.Rentals
{
    /// <summary>
    /// Thrown when a customer tries to return a vehicle that has already been returned (i.e., the rental is already closed).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class RentalAlreadyClosedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAlreadyClosedException"/> class.
        /// </summary>
        public RentalAlreadyClosedException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAlreadyClosedException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public RentalAlreadyClosedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAlreadyClosedException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public RentalAlreadyClosedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
