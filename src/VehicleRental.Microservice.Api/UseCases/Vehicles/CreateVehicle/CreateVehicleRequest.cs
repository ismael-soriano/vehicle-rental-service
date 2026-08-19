using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public required DateOnly ManufactureDate { get; set; }
    }
}
