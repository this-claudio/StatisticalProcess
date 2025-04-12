using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    MeasurementDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuoteData",
                schema: "StatisticalProcess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    measureId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteData_MeasurementData_measureId",
                        column: x => x.measureId,
                        principalSchema: "StatisticalProcess",
                        principalTable: "MeasurementData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteData_measureId",
                schema: "StatisticalProcess",
                table: "QuoteData",
                column: "measureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteData",
                schema: "StatisticalProcess");

            migrationBuilder.DropTable(
                name: "MeasurementData",
                schema: "StatisticalProcess");
        }
    }
}
