using Xunit;

namespace VehicleRental.Microservice.InfrastructureTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    public abstract class InfrastructureTestBase(GenericInfrastructureTestServerFixture fixture)
    {
        protected GenericInfrastructureTestServerFixture Fixture { get; } = fixture;
    }
}
