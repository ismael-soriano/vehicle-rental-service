using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles;

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
    }
}
