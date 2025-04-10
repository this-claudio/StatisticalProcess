using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticalProcess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuoteDate",
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
                    table.PrimaryKey("PK_QuoteDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteDate_MeasurementData_measureId",
                        column: x => x.measureId,
                        principalSchema: "StatisticalProcess",
                        principalTable: "MeasurementData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteDate_measureId",
                schema: "StatisticalProcess",
                table: "QuoteDate",
                column: "measureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteDate",
                schema: "StatisticalProcess");
        }
    }
}
