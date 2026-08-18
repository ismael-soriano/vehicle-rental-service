using System;
using System.Threading.Tasks;
using VehicleRental.Microservice.Domain.Interfaces;
using VehicleRental.Microservice.Domain.Rentals;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Use case for renting a vehicle. It handles the process of renting a vehicle to a customer, including validation and persistence of the rental information.
    /// </summary>
    public sealed class RentVehicleUseCase : IUseCase<RentVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalService _rentalService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRentVehicleOutputPort _outputPort;
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class with the specified dependencies.
        /// </summary>
        /// <param name="vehicleRepository">Provides persistence capabilities for the <see cref="Vehicle"/> aggregate.</param>
        /// <param name="rentalRepository">Provides persistence capabilities for the <see cref="Rental"/> aggregate.</param>
        /// <param name="rentalService">Service that handles the rental process of vehicles by customers.</param>
        /// <param name="unitOfWork">Unit of Work.</param>
        /// <param name="outputPort">Output Port for the Rent Vehicle Use Case.</param>
        /// <param name="timeProvider">Abstraction provider for time.</param>
        /// <exception cref="ArgumentNullException">Throws if any of the parameters is null.</exception>
        public RentVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentalRepository rentalRepository,
            RentalService rentalService,
            IUnitOfWork unitOfWork,
            IRentVehicleOutputPort outputPort,
            TimeProvider timeProvider)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        /// <summary>
        /// Executes the use case to rent a vehicle to a customer. It retrieves the vehicle, checks for availability, creates a rental, and persists the rental information.
        /// </summary>
        /// <param name="input">Input message for the Rent Vehicle Use Case.</param>
        /// <exception cref="ArgumentNullException">Throws if the input provided is null.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetById(new VehicleId(input.VehicleId));
            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"Vehicle {input.VehicleId} was not found.");
                return;
            }

            var customerId = new CustomerId(input.CustomerId);
            var rentedAt = _timeProvider.GetUtcNow().UtcDateTime;

            var rental = await _rentalService.Rent(vehicle, customerId, rentedAt);

            await _rentalRepository.Add(rental);
            await _unitOfWork.Save();

            _outputPort.StandardHandle(new RentVehicleOutput(
                rental.Id.ToGuid(), vehicle.Id.ToGuid(), customerId.ToGuid(), rentedAt));
        }
    }
}
