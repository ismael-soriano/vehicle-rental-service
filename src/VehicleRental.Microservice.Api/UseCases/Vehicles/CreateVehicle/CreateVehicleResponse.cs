using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    public sealed class CreateVehicleResponse
    {
        public CreateVehicleResponse(Guid vehicleId, string licensePlate)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
        }

        [Required]
        public Guid VehicleId { get; }

        [Required]
        public string LicensePlate { get; }
    }
}
