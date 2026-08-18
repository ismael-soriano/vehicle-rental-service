using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle
{
    public sealed class RentVehicleResponse
    {
        public RentVehicleResponse(Guid rentalId, Guid vehicleId, Guid customerId, DateTime rentedAt)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            CustomerId = customerId;
            RentedAt = rentedAt;
        }

        [Required]
        public Guid RentalId { get; }

        [Required]
        public Guid VehicleId { get; }

        [Required]
        public Guid CustomerId { get; }

        [Required]
        public DateTime RentedAt { get; }
    }
}
