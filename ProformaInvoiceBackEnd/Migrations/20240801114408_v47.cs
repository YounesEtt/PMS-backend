using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departement_plant_PlantId",
                table: "departement");

            migrationBuilder.DropIndex(
                name: "IX_departement_PlantId",
                table: "departement");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "departement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "departement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_departement_PlantId",
                table: "departement",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_departement_plant_PlantId",
                table: "departement",
                column: "PlantId",
                principalTable: "plant",
                principalColumn: "Id_plant",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
