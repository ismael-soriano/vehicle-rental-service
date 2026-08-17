using System;

[assembly: CLSCompliant(false)]

namespace VehicleRental.Microservice.Host.Configuration
{
    internal sealed class AppSettings
    {
        public string JwtAuthority { get; set; }
    }
}
