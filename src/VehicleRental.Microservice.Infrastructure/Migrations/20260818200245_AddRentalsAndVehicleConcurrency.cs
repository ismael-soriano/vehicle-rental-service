using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleRental.Microservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalsAndVehicleConcurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deliberately no AddColumn for "xmin" here: it is a PostgreSQL system
            // column present on every table already. EF Core only needs to be told
            // about it as a shadow property (see VehicleEntityConfiguration and the
            // model snapshot); creating it via migration would be both wrong and
            // rejected by PostgreSQL, since it is a reserved column name.
            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    RentedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId_ReturnedAt",
                table: "Rentals",
                columns: new[] { "CustomerId", "ReturnedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");
        }
    }
}
