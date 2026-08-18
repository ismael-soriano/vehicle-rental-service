using System;

namespace VehicleRental.Microservice.Domain.Rentals
{
    /// <summary>
    /// Represents the unique technical identity of a Customer.
    /// </summary>
    public readonly struct CustomerId : IEquatable<CustomerId>
    {
        private readonly Guid _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerId"/> struct.
        /// </summary>
        /// <param name="value">The underlying identifier value.</param>
        public CustomerId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("The customer identifier cannot be empty.", nameof(value));
            }

            _value = value;
        }

        /// <summary>
        /// Determines whether two specified <see cref="CustomerId"/> instances have the same value.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(CustomerId left, CustomerId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified <see cref="CustomerId"/> instances have different values.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(CustomerId left, CustomerId right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns the underlying <see cref="Guid"/> value.
        /// </summary>
        /// <returns>The underlying identifier value.</returns>
        public Guid ToGuid() => _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public bool Equals(CustomerId other) => _value.Equals(other._value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is CustomerId other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
