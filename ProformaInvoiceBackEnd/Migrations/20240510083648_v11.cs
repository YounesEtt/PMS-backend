using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessUnit",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "Cost_Center",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "DHL_Account",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "DiliveryAddress",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "InvoicesTypes",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "PN",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "ShippingPoint",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "UnitOfQuantity",
                table: "requestsItem");

            migrationBuilder.DropColumn(
                name: "incoterm",
                table: "requestsItem");

            migrationBuilder.RenameColumn(
                name: "scenario",
                table: "requestsItem",
                newName: "nameItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nameItem",
                table: "requestsItem",
                newName: "scenario");

            migrationBuilder.AddColumn<string>(
                name: "BusinessUnit",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cost_Center",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DHL_Account",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiliveryAddress",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InvoicesTypes",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PN",
                table: "requestsItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "requestsItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "requestsItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestNumber",
                table: "requestsItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShippingPoint",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfQuantity",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "incoterm",
                table: "requestsItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
