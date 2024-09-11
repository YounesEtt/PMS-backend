using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userplant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id_plant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userplant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userplant_plant_Id_plant",
                        column: x => x.Id_plant,
                        principalTable: "plant",
                        principalColumn: "Id_plant",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userplant_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userplant_Id_plant",
                table: "userplant",
                column: "Id_plant");

            migrationBuilder.CreateIndex(
                name: "IX_userplant_UserId",
                table: "userplant",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userplant");
        }
    }
}
