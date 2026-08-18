using System;
using System.Linq;
using System.Threading.Tasks;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Use Case to list all available vehicles.
    /// </summary>
    public sealed class ListAvailableVehiclesUseCase : IUseCase<ListAvailableVehiclesInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IListAvailableVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Provides persistence capabilities for the <see cref="Vehicle"/> aggregate.</param>
        /// <param name="outputPort">Output Port for the List Available Vehicles Use Case.</param>
        /// <exception cref="ArgumentNullException">Throws if any of the parameters is null.</exception>
        public ListAvailableVehiclesUseCase(
            IVehicleRepository vehicleRepository,
            IListAvailableVehiclesOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the List Available Vehicles Use Case.
        /// </summary>
        /// <param name="input">Input message for the List Available Vehicles Use Case.</param>
        /// <exception cref="ArgumentNullException">Throws if the input provided is null.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.GetAvailable();

            var result = vehicles
                .Select(v => new AvailableVehicle(v.Id.ToGuid(), v.LicensePlate.ToString(), v.ManufactureDate.ToDateOnly()))
                .ToList();

            _outputPort.StandardHandle(new ListAvailableVehiclesOutput(result));
        }
    }
}
