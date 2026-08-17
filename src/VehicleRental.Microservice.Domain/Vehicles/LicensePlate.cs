using System;

namespace VehicleRental.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents the license plate that uniquely identifies a vehicle for business purposes.
    /// </summary>
    public readonly struct LicensePlate : IEquatable<LicensePlate>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlate"/> struct.
        /// </summary>
        /// <param name="value">The license plate text.</param>
        public LicensePlate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new LicensePlateShouldNotBeEmptyException("The license plate is required.");
            }

            _value = value.Trim().ToUpperInvariant();
        }

        /// <summary>
        /// Determines whether two specified <see cref="LicensePlate"/> instances have the same value.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(LicensePlate left, LicensePlate right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified <see cref="LicensePlate"/> instances have different values.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(LicensePlate left, LicensePlate right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public override string ToString() => _value;

        /// <inheritdoc/>
        public bool Equals(LicensePlate other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is LicensePlate other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value is null ? 0 : _value.GetHashCode(StringComparison.Ordinal);
    }
}
