using System.Collections.Generic;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Output message for the List Available Vehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">List of available vehicles.</param>
        public ListAvailableVehiclesOutput(IReadOnlyCollection<AvailableVehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the list of available vehicles.
        /// </summary>
        public IReadOnlyCollection<AvailableVehicle> Vehicles { get; }
    }
}
