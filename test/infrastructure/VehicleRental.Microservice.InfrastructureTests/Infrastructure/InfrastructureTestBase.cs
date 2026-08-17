using Xunit;

namespace VehicleRental.Microservice.InfrastructureTests.Infrastructure
{
    [Collection(TestCollections.TestServer)]
    internal abstract class InfrastructureTestBase(GenericInfrastructureTestServerFixture fixture)
    {
        protected GenericInfrastructureTestServerFixture Fixture { get; } = fixture;
    }
}
