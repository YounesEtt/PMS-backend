using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "request");

            migrationBuilder.DropColumn(
                name: "ItemValue",
                table: "request");

            migrationBuilder.RenameColumn(
                name: "DiliveryAddress",
                table: "request",
                newName: "DeliveryAddress");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "request",
                newName: "DiliveryAddress");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "request",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemValue",
                table: "request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
