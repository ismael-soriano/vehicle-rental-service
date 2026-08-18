using System;
using MediatR;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    public sealed class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        public RentVehicleRequest(Guid vehicleId, Guid customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        public Guid VehicleId { get; }

        public Guid CustomerId { get; }
    }
}
