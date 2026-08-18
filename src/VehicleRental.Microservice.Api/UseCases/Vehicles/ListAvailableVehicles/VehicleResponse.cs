using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    public sealed class VehicleResponse
    {
        public VehicleResponse(Guid vehicleId, string licensePlate, DateOnly manufactureDate)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
            ManufactureDate = manufactureDate;
        }

        [Required]
        public Guid VehicleId { get; }

        [Required]
        public string LicensePlate { get; }

        [Required]
        public DateOnly ManufactureDate { get; }
    }
}
