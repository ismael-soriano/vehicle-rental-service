using Microsoft.AspNetCore.Mvc;

namespace VehicleRental.Microservice.Api.UseCases
{
    public interface IWebApiPresenter
    {
        IActionResult ActionResult { get; }
    }
}
