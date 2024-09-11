using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExporterAddress",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceAddress",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "ApproverRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "classe",
                table: "ApproverRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExporterAddress",
                table: "request");

            migrationBuilder.DropColumn(
                name: "InvoiceAddress",
                table: "request");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "ApproverRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "classe",
                table: "ApproverRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
