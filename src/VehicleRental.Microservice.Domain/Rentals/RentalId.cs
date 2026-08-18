using System;

namespace VehicleRental.Microservice.Domain.Rentals
{
    /// <summary>
    /// Represents the unique technical identity of a Rental.
    /// </summary>
    public readonly struct RentalId : IEquatable<RentalId>
    {
        private readonly Guid _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalId"/> struct.
        /// </summary>
        /// <param name="value">The underlying identifier value.</param>
        public RentalId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("The rental identifier cannot be empty.", nameof(value));
            }

            _value = value;
        }

        /// <summary>
        /// Determines whether two specified <see cref="RentalId"/> instances have the same value.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(RentalId left, RentalId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified <see cref="RentalId"/> instances have different values.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(RentalId left, RentalId right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Creates a new, unique <see cref="RentalId"/>.
        /// </summary>
        /// <returns>A new <see cref="RentalId"/>.</returns>
        public static RentalId New() => new(Guid.NewGuid());

        /// <summary>
        /// Returns the underlying <see cref="Guid"/> value.
        /// </summary>
        /// <returns>The underlying identifier value.</returns>
        public Guid ToGuid() => _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public bool Equals(RentalId other) => _value.Equals(other._value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is RentalId other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
