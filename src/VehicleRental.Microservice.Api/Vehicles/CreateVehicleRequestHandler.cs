using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleRental.Microservice.Api.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;

namespace VehicleRental.Microservice.Api.Vehicles
{
    public sealed class CreateVehicleRequestHandler(
        IUseCase<CreateVehicleInput> useCase,
        CreateVehiclePresenter presenter)
        : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new CreateVehicleInput(request.LicensePlate, request.ManufactureDate);
            await useCase.Execute(input);
            return presenter;
        }
    }
}
