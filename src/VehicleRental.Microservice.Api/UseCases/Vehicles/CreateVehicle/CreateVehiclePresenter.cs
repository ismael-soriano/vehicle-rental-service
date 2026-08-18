using System;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    public sealed class CreateVehiclePresenter : IWebApiPresenter, ICreateVehicleOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CreateVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var body = new CreateVehicleResponse(response.VehicleId, response.LicensePlate);
            ActionResult = new CreatedResult($"/vehicles/{body.VehicleId}", body);
        }
    }
}
