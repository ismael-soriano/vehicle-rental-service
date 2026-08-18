using System;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    public sealed class ReturnVehiclePresenter : IWebApiPresenter, IReturnVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ReturnVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);
            var body = new ReturnVehicleResponse(response.RentalId, response.VehicleId, response.ReturnedAt);
            ActionResult = new OkObjectResult(body); // 200, no 201: no se crea nada nuevo
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }
    }
}
