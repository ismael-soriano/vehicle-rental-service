using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    public sealed class ListAvailableVehiclesPresenter : IWebApiPresenter, IListAvailableVehiclesOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAvailableVehiclesOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var body = response.Vehicles
                .Select(v => new VehicleResponse(v.VehicleId, v.LicensePlate, v.ManufactureDate))
                .ToList();

            ActionResult = new OkObjectResult(body);
        }
    }
}
