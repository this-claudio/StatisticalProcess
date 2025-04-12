using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImproveValuePrecision4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                schema: "StatisticalProcess",
                table: "QuoteData",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementData_MeasurementDateTime",
                schema: "StatisticalProcess",
                table: "MeasurementData",
                column: "MeasurementDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeasurementData_MeasurementDateTime",
                schema: "StatisticalProcess",
                table: "MeasurementData");

            migrationBuilder.AlterColumn<decimal>(
                name: "value",
                schema: "StatisticalProcess",
                table: "QuoteData",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);
        }
    }
}
