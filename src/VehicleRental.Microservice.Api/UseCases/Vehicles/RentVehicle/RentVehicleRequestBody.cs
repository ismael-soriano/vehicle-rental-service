using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    public sealed class RentVehicleRequestBody
    {
        [Required]
        required public Guid CustomerId { get; set; }
    }
}
