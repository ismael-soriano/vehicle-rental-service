using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Microservice.Api.UseCases;
using VehicleRental.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using VehicleRental.Microservice.Api.UseCases.Vehicles.RentVehicle;
using VehicleRental.Microservice.Api.UseCases.Vehicles.ReturnVehicle;
using VehicleRental.Microservice.Domain.Rentals.Exceptions;
using VehicleRental.Microservice.Domain.Vehicles.Exceptions;
using VehicleRental.Microservice.FunctionalTests.Infrastructure;
using Xunit;

namespace VehicleRental.Microservice.FunctionalTests.Specs
{
    public sealed class RentAndReturnVehicleTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task RentAndReturn_FullCycle_EnforcesBussinessRulesAndSucceds()
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var firstCustomerId = Guid.NewGuid();
            var secondCustomerId = Guid.NewGuid();

            // Create 2 vehicles
            var firstVehicleId = await CreateVehicleAsync("ABC123", today.AddYears(-1));
            var secondVehicleId = await CreateVehicleAsync("XYZ789", today.AddYears(-1));

            // Rent vehicle 1 (should succeed)
            var firstRentResult = await RentVehicleAsync(firstVehicleId, firstCustomerId);
            var firstRentBody = firstRentResult.Should().BeOfType<CreatedResult>().Subject
                .Value.Should().BeOfType<RentVehicleResponse>().Subject;
            firstRentBody.VehicleId.Should().Be(firstVehicleId);

            // Try to rent vehicle 1 with another customer (should fail)
            Func<Task> rentSameVehicleAgain = () => RentVehicleAsync(firstVehicleId, secondCustomerId);
            await rentSameVehicleAgain.Should().ThrowAsync<VehicleNotAvailableException>();

            // The same customer cannot rent another vehicle while having an active rental (should fail)
            Func<Task> rentSecondVehicleSameCustomer = () => RentVehicleAsync(secondVehicleId, firstCustomerId);
            await rentSecondVehicleSameCustomer.Should().ThrowAsync<CustomerAlreadyHasActiveRentalException>();

            // Return vehicle 1 (should succeed)
            var returnResult = await ReturnVehicleAsync(firstVehicleId);
            var returnBody = returnResult.Should().BeOfType<OkObjectResult>().Subject
                .Value.Should().BeOfType<ReturnVehicleResponse>().Subject;
            returnBody.RentalId.Should().Be(firstRentBody.RentalId);

            // Try to return vehicle 1 again (should fail)
            Func<Task> returnSameVehicleAgain = () => ReturnVehicleAsync(firstVehicleId);
            await returnSameVehicleAgain.Should().ThrowAsync<VehicleNotRentedException>();

            // Now the customer can rent another vehicle (should succeed)
            var secondRentResult = await RentVehicleAsync(secondVehicleId, firstCustomerId);
            secondRentResult.Should().BeOfType<CreatedResult>().Subject
                .Value.Should().BeOfType<RentVehicleResponse>().Subject
                .VehicleId.Should().Be(secondVehicleId);
        }

        private async Task<Guid> CreateVehicleAsync(string licensePlate, DateOnly manufactureDate)
        {
            IWebApiPresenter presenter = null;

            await Fixture.UsingHandlerForRequestResponse<CreateVehicleRequest, IWebApiPresenter>(async handler =>
            {
                var request = new CreateVehicleRequest
                {
                    LicensePlate = licensePlate,
                    ManufactureDate = manufactureDate
                };
                presenter = await handler.Handle(request, CancellationToken.None);
            });

            var body = presenter
                .ActionResult.Should().BeOfType<CreatedResult>().Subject
                .Value.Should().BeOfType<CreateVehicleResponse>().Subject;

            return body.VehicleId;
        }

        private async Task<IActionResult> RentVehicleAsync(Guid vehicleId, Guid customerId)
        {
            IWebApiPresenter presenter = null;

            await Fixture.UsingHandlerForRequestResponse<RentVehicleRequest, IWebApiPresenter>(async handler =>
            {
                presenter = await handler.Handle(new RentVehicleRequest(vehicleId, customerId), CancellationToken.None);
            });

            return presenter.ActionResult;
        }

        private async Task<IActionResult> ReturnVehicleAsync(Guid vehicleId)
        {
            IWebApiPresenter presenter = null;

            await Fixture.UsingHandlerForRequestResponse<ReturnVehicleRequest, IWebApiPresenter>(async handler =>
            {
                presenter = await handler.Handle(new ReturnVehicleRequest(vehicleId), CancellationToken.None);
            });

            return presenter.ActionResult;
        }
    }
}
