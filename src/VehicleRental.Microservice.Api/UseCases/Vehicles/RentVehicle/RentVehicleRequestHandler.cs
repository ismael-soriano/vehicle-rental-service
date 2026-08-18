using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleRental.Microservice.ApplicationCore.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    public sealed class RentVehicleRequestHandler(
        IUseCase<RentVehicleInput> useCase,
        RentVehiclePresenter presenter)
        : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            await useCase.Execute(new RentVehicleInput(request.VehicleId, request.CustomerId));
            return presenter;
        }
    }
}
