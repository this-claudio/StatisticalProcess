using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "StatisticalProcess");

            migrationBuilder.CreateTable(
                name: "MeasurementData",
                schema: "StatisticalProcess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasurementValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MeasurementDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementData",
                schema: "StatisticalProcess");
        }
    }
}
