using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleRental.Microservice.ApplicationCore.UseCases;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    public sealed class ListAvailableVehiclesRequestHandler(
        IUseCase<ListAvailableVehiclesInput> useCase,
        ListAvailableVehiclesPresenter presenter)
        : IRequestHandler<ListAvailableVehiclesRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(ListAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new ListAvailableVehiclesInput());
            return presenter;
        }
    }
}
