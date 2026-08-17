using Xunit;

namespace VehicleRental.Microservice.FunctionalTests.Infrastructure
{
    [CollectionDefinition(TestCollections.Functional)]
    public class CompositionRootCollectionFixture : ICollectionFixture<CompositionRootTestFixture>
    {
    }
}
