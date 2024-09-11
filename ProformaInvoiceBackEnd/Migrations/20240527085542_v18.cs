using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint first
            migrationBuilder.DropPrimaryKey(
                name: "PK_request",
                table: "request");

            // Drop any other IDENTITY column if it exists
            migrationBuilder.DropColumn(
                name: "Id_request",
                table: "request");

            // Drop the existing RequestNumber column
            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "request");

            // Add the RequestNumber column with the IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "RequestNumber",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Add the primary key constraint to the new column
            migrationBuilder.AddPrimaryKey(
                name: "PK_request",
                table: "request",
                column: "RequestNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_request",
                table: "request");

            // Drop the RequestNumber column
            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "request");

            // Recreate the original Id_request column with the IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "Id_request",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Recreate the original RequestNumber column without the IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "RequestNumber",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Add the primary key constraint back to Id_request
            migrationBuilder.AddPrimaryKey(
                name: "PK_request",
                table: "request",
                column: "Id_request");
        }
    }
}
