using Xunit;

namespace VehicleRental.Microservice.InfrastructureTests.Infrastructure
{
    [CollectionDefinition(TestCollections.TestServer)]
    public class TestServerCollectionFixture : ICollectionFixture<GenericInfrastructureTestServerFixture>
    {
    }
}
