using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemValue",
                table: "request",
                newName: "WEIGHT");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "request",
                newName: "UNITVALUEFINANCE");

            migrationBuilder.AddColumn<string>(
                name: "BUSINESSUNIT",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COO",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COSTCENTER",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DHLACCOUNT",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTSCODE",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NUMBEROFBOXES",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PN",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PPLANTN",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QUANTITY",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRACKINGNUMBER",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UNITOFQUANTITY",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BUSINESSUNIT",
                table: "request");

            migrationBuilder.DropColumn(
                name: "COO",
                table: "request");

            migrationBuilder.DropColumn(
                name: "COSTCENTER",
                table: "request");

            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "request");

            migrationBuilder.DropColumn(
                name: "DHLACCOUNT",
                table: "request");

            migrationBuilder.DropColumn(
                name: "HTSCODE",
                table: "request");

            migrationBuilder.DropColumn(
                name: "NUMBEROFBOXES",
                table: "request");

            migrationBuilder.DropColumn(
                name: "PN",
                table: "request");

            migrationBuilder.DropColumn(
                name: "PPLANTN",
                table: "request");

            migrationBuilder.DropColumn(
                name: "QUANTITY",
                table: "request");

            migrationBuilder.DropColumn(
                name: "TRACKINGNUMBER",
                table: "request");

            migrationBuilder.DropColumn(
                name: "UNITOFQUANTITY",
                table: "request");

            migrationBuilder.RenameColumn(
                name: "WEIGHT",
                table: "request",
                newName: "ItemValue");

            migrationBuilder.RenameColumn(
                name: "UNITVALUEFINANCE",
                table: "request",
                newName: "ItemName");
        }
    }
}
