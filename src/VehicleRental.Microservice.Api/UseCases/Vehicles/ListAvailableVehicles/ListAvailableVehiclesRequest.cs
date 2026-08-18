using MediatR;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    public sealed class ListAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
