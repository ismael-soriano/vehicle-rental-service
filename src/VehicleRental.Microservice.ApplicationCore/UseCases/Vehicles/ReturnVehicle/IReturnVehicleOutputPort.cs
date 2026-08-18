namespace VehicleRental.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Output port interface for the use case of returning a vehicle.
    /// </summary>
    public interface IReturnVehicleOutputPort : IOutputPortStandard<ReturnVehicleOutput>, IOutputPortNotFound
    {
    }
}
