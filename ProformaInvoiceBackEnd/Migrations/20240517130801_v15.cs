using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantDepartement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_plant = table.Column<int>(type: "int", nullable: false),
                    Id_departement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantDepartement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantDepartement_departement_Id_departement",
                        column: x => x.Id_departement,
                        principalTable: "departement",
                        principalColumn: "Id_departement",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantDepartement_plant_Id_plant",
                        column: x => x.Id_plant,
                        principalTable: "plant",
                        principalColumn: "Id_plant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantDepartement_Id_departement",
                table: "PlantDepartement",
                column: "Id_departement");

            migrationBuilder.CreateIndex(
                name: "IX_PlantDepartement_Id_plant",
                table: "PlantDepartement",
                column: "Id_plant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantDepartement");
        }
    }
}
