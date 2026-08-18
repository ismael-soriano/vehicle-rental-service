using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using VehicleRental.Microservice.Api.UseCases;

namespace VehicleRental.Microservice.Api.Vehicles
{
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string LicensePlate { get; set; }

        [Required]
        required public DateOnly ManufactureDate { get; set; }
    }
}
