using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleRental.Microservice.ApplicationCore.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    public sealed class ReturnVehicleRequestHandler(
        IUseCase<ReturnVehicleInput> useCase,
        ReturnVehiclePresenter presenter)
        : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            await useCase.Execute(new ReturnVehicleInput(request.VehicleId));
            return presenter;
        }
    }
}
