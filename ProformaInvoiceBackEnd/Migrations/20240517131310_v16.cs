using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departement_plant_plantId",
                table: "departement");

            migrationBuilder.DropIndex(
                name: "IX_departement_plantId",
                table: "departement");

            migrationBuilder.DropColumn(
                name: "plantId",
                table: "departement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "plantId",
                table: "departement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_departement_plantId",
                table: "departement",
                column: "plantId");

            migrationBuilder.AddForeignKey(
                name: "FK_departement_plant_plantId",
                table: "departement",
                column: "plantId",
                principalTable: "plant",
                principalColumn: "Id_plant",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
