using System;
using System.Diagnostics.CodeAnalysis;

namespace VehicleRental.Microservice.Domain.Vehicles.Exceptions
{
    /// <summary>
    /// Thrown when a manufacture date is set in the future.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ManufactureDateCannotBeInTheFutureException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureDateCannotBeInTheFutureException"/> class.
        /// </summary>
        public ManufactureDateCannotBeInTheFutureException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureDateCannotBeInTheFutureException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public ManufactureDateCannotBeInTheFutureException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureDateCannotBeInTheFutureException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManufactureDateCannotBeInTheFutureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
