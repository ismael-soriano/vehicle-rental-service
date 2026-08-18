using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleRental.Microservice.Domain.Rentals;
using VehicleRental.Microservice.Domain.Rentals.ValueObjects;
using VehicleRental.Microservice.Domain.Vehicles.ValueObjects;

namespace VehicleRental.Microservice.Infrastructure.Persistence.Configurations
{
    internal sealed class RentalEntityConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rentals");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasConversion(id => id.ToGuid(), value => new RentalId(value))
                .ValueGeneratedNever();

            builder.Property(r => r.VehicleId)
                .HasConversion(id => id.ToGuid(), value => new VehicleId(value))
                .IsRequired();

            builder.Property(r => r.CustomerId)
                .HasConversion(id => id.ToGuid(), value => new CustomerId(value))
                .IsRequired();

            builder.Property(r => r.RentedAt).IsRequired();
            builder.Property(r => r.ReturnedAt);

            builder.HasIndex(r => new { r.CustomerId, r.ReturnedAt });
        }
    }
}
