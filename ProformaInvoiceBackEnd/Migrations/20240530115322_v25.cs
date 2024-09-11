using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    public partial class v25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Create the new Approverscenario table
            migrationBuilder.CreateTable(
                name: "Approverscenario",
                columns: table => new
                {
                    id_approver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classe = table.Column<int>(type: "int", nullable: false),
                    scenarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approverscenario", x => x.id_approver);
                    table.ForeignKey(
                        name: "FK_Approverscenario_scenario_scenarioId",
                        column: x => x.scenarioId,
                        principalTable: "scenario",
                        principalColumn: "Id_scenario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approverscenario_scenarioId",
                table: "Approverscenario",
                column: "scenarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approverscenario");
        }
    }
}
