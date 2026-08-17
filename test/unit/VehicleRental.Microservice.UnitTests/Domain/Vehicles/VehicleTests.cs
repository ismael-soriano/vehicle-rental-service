using System;
using FluentAssertions;
using VehicleRental.Microservice.Domain.Vehicles;
using Xunit;

namespace VehicleRental.Microservice.UnitTests.Domain.Vehicles
{
    public class VehicleTests
    {
        [Fact]
        public void Create_WithManufactureDateWithinFleetAge_ReturnsAvailableVehicle()
        {
            var today = new DateOnly(2024, 1, 1);
            var manufactureDate = new ManufactureDate(today.AddYears(-3), today); // 3 years old vehicle
            var licensePlate = new LicensePlate("ABC123");

            var vehicle = Vehicle.Create(licensePlate, manufactureDate, today);

            vehicle.Status.Should().Be(VehicleStatus.Available);
        }

        [Fact]
        public void Create_WithManufactureDateOfExactlyFiveYears_ReturnsAvailableVehicle()
        {
            var today = new DateOnly(2024, 1, 1);
            var manufactureDate = new ManufactureDate(today.AddYears(-5), today); // 5 years old vehicle
            var licensePlate = new LicensePlate("ABC123");

            var vehicle = Vehicle.Create(licensePlate, manufactureDate, today);

            vehicle.Status.Should().Be(VehicleStatus.Available);
        }

        [Fact]
        public void Create_WithManufactureDateOlderThanFiveYears_ThrowsVehicleTooOldException()
        {
            var today = new DateOnly(2024, 1, 1);
            var manufactureDate = new ManufactureDate(today.AddYears(-6), today); // 6 years old vehicle
            var licensePlate = new LicensePlate("ABC123");

            Action act = () => Vehicle.Create(licensePlate, manufactureDate, today);

            act.Should().Throw<VehicleTooOldException>();
        }
    }
}
