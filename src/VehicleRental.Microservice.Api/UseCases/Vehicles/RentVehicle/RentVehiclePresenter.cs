using System;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(RentVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);
            var body = new RentVehicleResponse(response.RentalId, response.VehicleId, response.CustomerId, response.RentedAt);
            ActionResult = new CreatedResult($"/api/rentals/{body.RentalId}", body);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }
    }
}
