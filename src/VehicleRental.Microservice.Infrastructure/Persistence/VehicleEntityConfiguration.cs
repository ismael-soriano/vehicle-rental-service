using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleRental.Microservice.Domain.Vehicles;

namespace VehicleRental.Microservice.Infrastructure.Persistence
{
    internal sealed class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(id => id.ToGuid(), value => new VehicleId(value))
                .ValueGeneratedNever();

            builder.Property(v => v.LicensePlate)
                .HasConversion(lp => lp.ToString(), value => new LicensePlate(value))
                .HasMaxLength(16)
                .IsRequired();

            builder.HasIndex(v => v.LicensePlate).IsUnique();

            builder.Property(v => v.ManufactureDate)
                .HasConversion(
                    md => md.ToDateOnly(),
                    value => new ManufactureDate(value, value)) // We trust the value stored on the db and never revalidate
                .IsRequired();

            builder.Property(v => v.Status)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
