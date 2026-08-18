using System;
using MediatR;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    public sealed class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        public ReturnVehicleRequest(Guid vehicleId)
        {
            VehicleId = vehicleId;
        }

        public Guid VehicleId { get; }
    }
}
