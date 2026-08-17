using Microsoft.Extensions.DependencyInjection;

namespace VehicleRental.Microservice.Infrastructure.Interfaces
{
    public interface IInfrastructureBuilder
    {
        IServiceCollection Services { get; }
    }
}
