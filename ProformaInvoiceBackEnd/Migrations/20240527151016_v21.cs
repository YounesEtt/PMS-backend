using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the shippoint table
            migrationBuilder.CreateTable(
                name: "shippoint",
                columns: table => new
                {
                    id_ship = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippoint", x => x.id_ship);
                });

            // Add shipId column to request table
            migrationBuilder.AddColumn<int>(
                name: "shipId",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Create index for the foreign key column
            migrationBuilder.CreateIndex(
                name: "IX_request_shipId",
                table: "request",
                column: "shipId");

            // Add foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_request_shippoint_shipId",
                table: "request",
                column: "shipId",
                principalTable: "shippoint",
                principalColumn: "id_ship",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_request_shippoint_shipId",
                table: "request");

            // Drop index for the foreign key column
            migrationBuilder.DropIndex(
                name: "IX_request_shipId",
                table: "request");

            // Drop shipId column from request table
            migrationBuilder.DropColumn(
                name: "shipId",
                table: "request");

            // Drop shippoint table
            migrationBuilder.DropTable(
                name: "shippoint");
        }
    }
}
