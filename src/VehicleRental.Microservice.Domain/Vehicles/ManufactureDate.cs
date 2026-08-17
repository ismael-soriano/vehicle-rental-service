using System;

namespace VehicleRental.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents the manufacture date of a vehicle.
    /// </summary>
    public readonly struct ManufactureDate : IEquatable<ManufactureDate>
    {
        private readonly DateOnly _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufactureDate"/> struct.
        /// </summary>
        /// <param name="value">The manufacture date.</param>
        /// <param name="today">The current date, resolved by the caller.</param>
        public ManufactureDate(DateOnly value, DateOnly today)
        {
            if (value > today)
            {
                throw new ManufactureDateCannotBeInTheFutureException(
                    $"The manufacture date {value:yyyy-MM-dd} cannot be in the future.");
            }

            _value = value;
        }

        /// <summary>
        /// Determines whether two specified <see cref="ManufactureDate"/> instances have the same value.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(ManufactureDate left, ManufactureDate right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified <see cref="ManufactureDate"/> instances have different values.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns><see langword="true"/> if the values are not equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(ManufactureDate left, ManufactureDate right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Calculates the age in whole years relative to a reference date.
        /// </summary>
        /// <param name="asOf">The reference date to calculate the age against.</param>
        /// <returns>The age in whole years.</returns>
        public int AgeInYears(DateOnly asOf)
        {
            var age = asOf.Year - _value.Year;

            if (asOf.DayOfYear < _value.DayOfYear)
            {
                age--;
            }

            return age;
        }

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

        /// <inheritdoc/>
        public bool Equals(ManufactureDate other) => _value.Equals(other._value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ManufactureDate other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
