using System;
using System.Threading.Tasks;
using VehicleRental.Microservice.Domain.Interfaces;
using VehicleRental.Microservice.Domain.Rentals;
using VehicleRental.Microservice.Domain.Vehicles;
using VehicleRental.Microservice.Domain.Vehicles.Exceptions;
using VehicleRental.Microservice.Domain.Vehicles.ValueObjects;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Represents the use case for returning a rented vehicle.
    /// </summary>
    public sealed class ReturnVehicleUseCase : IUseCase<ReturnVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReturnVehicleOutputPort _outputPort;
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Provides persistence capabilities for the <see cref="Vehicle"/> aggregate.</param>
        /// <param name="rentalRepository">Provides persistence capabilities for the <see cref="Rental"/> aggregate.</param>
        /// <param name="unitOfWork">Unit of Work.</param>
        /// <param name="outputPort">Output Port for the Rent Vehicle Use Case.</param>
        /// <param name="timeProvider">Abstraction provider for time.</param>
        /// <exception cref="ArgumentNullException">Throws if any of the parameters is null.</exception>
        public ReturnVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentalRepository rentalRepository,
            IUnitOfWork unitOfWork,
            IReturnVehicleOutputPort outputPort,
            TimeProvider timeProvider)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        /// <summary>
        /// Executes the use case of returning a rented vehicle.
        /// </summary>
        /// <param name="input">Input message for the Return Vehicle Use Case.</param>
        /// <exception cref="ArgumentNullException">Throws if the input provided is null.</exception>
        /// <exception cref="VehicleNotRentedException">Throws if the vehicle you are trying to return is not currently rented.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = new VehicleId(input.VehicleId);
            var vehicle = await _vehicleRepository.GetById(vehicleId);
            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"Vehicle {input.VehicleId} was not found.");
                return;
            }

            var rental = await _rentalRepository.GetActiveByVehicle(vehicleId);
            if (rental is null)
            {
                throw new VehicleNotRentedException($"Vehicle {input.VehicleId} is not currently rented.");
            }

            var returnedAt = _timeProvider.GetUtcNow().UtcDateTime;

            vehicle.Return();
            rental.Return(returnedAt);

            await _unitOfWork.Save();

            _outputPort.StandardHandle(new ReturnVehicleOutput(rental.Id.ToGuid(), vehicle.Id.ToGuid(), returnedAt));
        }
    }
}
