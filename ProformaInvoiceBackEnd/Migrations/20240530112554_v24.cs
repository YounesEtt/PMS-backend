using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scenario_approver_approverId",
                table: "scenario");

            migrationBuilder.DropIndex(
                name: "IX_scenario_approverId",
                table: "scenario");

            migrationBuilder.DropColumn(
                name: "approverId",
                table: "scenario");

            migrationBuilder.AddColumn<int>(
                name: "Id_scenario",
                table: "approver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "scenarioId_scenario",
                table: "approver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_approver_scenarioId_scenario",
                table: "approver",
                column: "scenarioId_scenario");

            migrationBuilder.AddForeignKey(
                name: "FK_approver_scenario_scenarioId_scenario",
                table: "approver",
                column: "scenarioId_scenario",
                principalTable: "scenario",
                principalColumn: "Id_scenario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_approver_scenario_scenarioId_scenario",
                table: "approver");

            migrationBuilder.DropIndex(
                name: "IX_approver_scenarioId_scenario",
                table: "approver");

            migrationBuilder.DropColumn(
                name: "Id_scenario",
                table: "approver");

            migrationBuilder.DropColumn(
                name: "scenarioId_scenario",
                table: "approver");

            migrationBuilder.AddColumn<int>(
                name: "approverId",
                table: "scenario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_scenario_approverId",
                table: "scenario",
                column: "approverId");

            migrationBuilder.AddForeignKey(
                name: "FK_scenario_approver_approverId",
                table: "scenario",
                column: "approverId",
                principalTable: "approver",
                principalColumn: "id_approver",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
