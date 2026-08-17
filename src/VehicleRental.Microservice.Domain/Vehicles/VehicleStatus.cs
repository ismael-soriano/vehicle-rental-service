namespace VehicleRental.Microservice.Domain.Vehicles
{
    /// <summary>
    /// Represents the availability status of a <see cref="Vehicle"/>.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// The vehicle is part of the fleet and can be rented.
        /// </summary>
        Available,

        /// <summary>
        /// The vehicle is currently rented and cannot be rented again until returned.
        /// </summary>
        Rented,
    }
}
