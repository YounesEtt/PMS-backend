using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessUnit",
                table: "request");

            migrationBuilder.DropColumn(
                name: "Cost_Center",
                table: "request");

            migrationBuilder.DropColumn(
                name: "DHL_Account",
                table: "request");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "request");

            migrationBuilder.DropColumn(
                name: "PN",
                table: "request");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "request");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "request");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "request");

            migrationBuilder.DropColumn(
                name: "UnitOfQuantity",
                table: "request");

            migrationBuilder.DropColumn(
                name: "scenarioName",
                table: "request");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessUnit",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cost_Center",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DHL_Account",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PN",
                table: "request",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "request",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "request",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfQuantity",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "scenarioName",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
