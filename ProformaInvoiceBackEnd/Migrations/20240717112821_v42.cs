using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BUSINESSUNIT",
                table: "request");

            migrationBuilder.DropColumn(
                name: "COSTCENTER",
                table: "request");

            migrationBuilder.DropColumn(
                name: "DESCRIPTION",
                table: "request");

            migrationBuilder.DropColumn(
                name: "PLANT",
                table: "request");

            migrationBuilder.DropColumn(
                name: "PN",
                table: "request");

            migrationBuilder.DropColumn(
                name: "QUANTITY",
                table: "request");

            migrationBuilder.DropColumn(
                name: "UNITVALUEFINANCE",
                table: "request");

            migrationBuilder.RenameColumn(
                name: "UNITOFQUANTITY",
                table: "request",
                newName: "operationtype");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id_items = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUANTITY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UNITOFQUANTITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UNITVALUEFINANCE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COSTCENTER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BUSINESSUNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLANT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id_items);
                    table.ForeignKey(
                        name: "FK_Item_request_RequestNumber",
                        column: x => x.RequestNumber,
                        principalTable: "request",
                        principalColumn: "RequestNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_RequestNumber",
                table: "Item",
                column: "RequestNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.RenameColumn(
                name: "operationtype",
                table: "request",
                newName: "UNITOFQUANTITY");

            migrationBuilder.AddColumn<string>(
                name: "BUSINESSUNIT",
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
                name: "PLANT",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PN",
                table: "request",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "QUANTITY",
                table: "request",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UNITVALUEFINANCE",
                table: "request",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
