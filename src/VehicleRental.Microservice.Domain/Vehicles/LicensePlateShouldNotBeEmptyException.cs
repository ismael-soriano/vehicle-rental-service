using System;
using System.Diagnostics.CodeAnalysis;

namespace VehicleRental.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Thrown when a license plate is empty or whitespace.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class LicensePlateShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlateShouldNotBeEmptyException"/> class.
        /// </summary>
        public LicensePlateShouldNotBeEmptyException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlateShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public LicensePlateShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlateShouldNotBeEmptyException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public LicensePlateShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
