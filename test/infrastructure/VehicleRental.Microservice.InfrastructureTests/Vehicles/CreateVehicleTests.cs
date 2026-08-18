using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using VehicleRental.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace VehicleRental.Microservice.InfrastructureTests.Vehicles
{
    [Collection(TestCollections.TestServer)]
    public sealed class CreateVehicleTests(GenericInfrastructureTestServerFixture fixture)
        : InfrastructureTestBase(fixture)
    {
        [Fact]
        public async Task Post_WithEmptyLicensePlate_ReturnsBadRequest()
        {
            var client = Fixture.Server.CreateClient();

            var response = await client.PostAsJsonAsync("/api/vehicles", new
            {
                LicensePlate = string.Empty,
                ManufactureDate = "2022-01-01"
            });

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
