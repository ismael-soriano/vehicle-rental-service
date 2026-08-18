using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehicleRental.Microservice.Api.Vehicles
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
    }
}
