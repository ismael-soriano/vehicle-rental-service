using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.ReturnVehicle
{
    public sealed class ReturnVehicleResponse
    {
        public ReturnVehicleResponse(Guid rentalId, Guid vehicleId, DateTime returnedAt)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            ReturnedAt = returnedAt;
        }

        [Required]
        public Guid RentalId { get; }

        [Required]
        public Guid VehicleId { get; }

        [Required]
        public DateTime ReturnedAt { get; }
    }
}
