using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_ship",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shippointid_ship",
                table: "request",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_request_shippointid_ship",
                table: "request",
                column: "shippointid_ship");

            migrationBuilder.AddForeignKey(
                name: "FK_request_shippoint_shippointid_ship",
                table: "request",
                column: "shippointid_ship",
                principalTable: "shippoint",
                principalColumn: "id_ship");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_request_shippoint_shippointid_ship",
                table: "request");

            migrationBuilder.DropTable(
                name: "shippoint");

            migrationBuilder.DropIndex(
                name: "IX_request_shippointid_ship",
                table: "request");

            migrationBuilder.DropColumn(
                name: "id_ship",
                table: "request");

            migrationBuilder.DropColumn(
                name: "shippointid_ship",
                table: "request");
        }
    }
}
