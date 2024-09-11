using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "approver");

            migrationBuilder.DropColumn(
                name: "comment",
                table: "approver");

            migrationBuilder.DropColumn(
                name: "status",
                table: "approver");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "approver",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "approver",
                newName: "classe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "approver",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "classe",
                table: "approver",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "approver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "approver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "approver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
