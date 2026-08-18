using System;
using System.Threading.Tasks;
using VehicleRental.Microservice.Domain.Interfaces;
using VehicleRental.Microservice.Domain.Vehicles;
using VehicleRental.Microservice.Domain.Vehicles.ValueObjects;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Handler for the Create Vehicle Use Case.
    /// </summary>
    public sealed class CreateVehicleUseCase : IUseCase<CreateVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateVehicleOutputPort _outputPort;
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Provides persistence capabilities for the <see cref="Vehicle"/> aggregate.</param>
        /// <param name="unitOfWork">Unit of Work.</param>
        /// <param name="outputPort">Output Port for the Create Vehicle Use Case.</param>
        /// <param name="timeProvider">Abstraction provider for time.</param>
        /// <exception cref="ArgumentNullException">Throws if any of the parameters is null.</exception>
        public CreateVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork,
            ICreateVehicleOutputPort outputPort,
            TimeProvider timeProvider)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        /// <summary>
        /// Executes the Create Vehicle Use Case.
        /// </summary>
        /// <param name="input">Input message for the Create Vehicle Use Case.</param>
        /// <exception cref="ArgumentNullException">Throws if the input provided is null.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var today = DateOnly.FromDateTime(_timeProvider.GetUtcNow().UtcDateTime);
            var licensePlate = new LicensePlate(input.LicensePlate);
            var manufactureDate = new ManufactureDate(input.ManufactureDate, today);

            var vehicle = Vehicle.Create(licensePlate, manufactureDate, today);

            await _vehicleRepository.Add(vehicle);
            await _unitOfWork.Save();

            _outputPort.StandardHandle(new CreateVehicleOutput(vehicle.Id.ToGuid(), vehicle.LicensePlate.ToString()));
        }
    }
}
