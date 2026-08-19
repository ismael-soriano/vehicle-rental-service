using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    public sealed class RentVehicleRequestBody
    {
        [Required]
        public required Guid CustomerId { get; set; }
    }
}
