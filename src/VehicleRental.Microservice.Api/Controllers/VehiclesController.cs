using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles;
using VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle;
using VehicleRental.Microservice.Api.UseCases.Vehicles.ReturnVehicle;

namespace VehicleRental.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class VehiclesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateVehicleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateVehicleRequest request)
        {
            var presenter = await mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<VehicleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var presenter = await mediator.Send(new ListAvailableVehiclesRequest());
            return presenter.ActionResult;
        }

        [HttpPost("{vehicleId:guid}/rentals")]
        [ProducesResponseType(typeof(RentVehicleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostRental(Guid vehicleId, [FromBody] RentVehicleRequestBody body)
        {
            ArgumentNullException.ThrowIfNull(body);

            var presenter = await mediator.Send(new RentVehicleRequest(vehicleId, body.CustomerId));
            return presenter.ActionResult;
        }

        [HttpPost("{vehicleId:guid}/return")]
        [ProducesResponseType(typeof(ReturnVehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostReturn(Guid vehicleId)
        {
            var presenter = await mediator.Send(new ReturnVehicleRequest(vehicleId));
            return presenter.ActionResult;
        }
    }
}
