using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scenarioItemsConfiguration_requestsItem_request_itemId_request_item",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_scenarioItemsConfiguration_scenario_scenarioId_scenario",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_scenarioItemsConfiguration",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_scenarioItemsConfiguration_Id_scenario",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_scenarioItemsConfiguration_request_itemId_request_item",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_scenarioItemsConfiguration_scenarioId_scenario",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropColumn(
                name: "request_itemId_request_item",
                table: "scenarioItemsConfiguration");

            migrationBuilder.DropColumn(
                name: "scenarioId_scenario",
                table: "scenarioItemsConfiguration");

            migrationBuilder.AlterColumn<int>(
                name: "nPlus1",
                table: "user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_scenarioItemsConfiguration",
                table: "scenarioItemsConfiguration",
                columns: new[] { "Id_scenario", "Id_request_item" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_scenarioItemsConfiguration",
                table: "scenarioItemsConfiguration");

            migrationBuilder.AlterColumn<int>(
                name: "nPlus1",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "request_itemId_request_item",
                table: "scenarioItemsConfiguration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "scenarioId_scenario",
                table: "scenarioItemsConfiguration",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_scenarioItemsConfiguration",
                table: "scenarioItemsConfiguration",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioItemsConfiguration_Id_scenario",
                table: "scenarioItemsConfiguration",
                column: "Id_scenario");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioItemsConfiguration_request_itemId_request_item",
                table: "scenarioItemsConfiguration",
                column: "request_itemId_request_item");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioItemsConfiguration_scenarioId_scenario",
                table: "scenarioItemsConfiguration",
                column: "scenarioId_scenario");

            migrationBuilder.AddForeignKey(
                name: "FK_scenarioItemsConfiguration_requestsItem_request_itemId_request_item",
                table: "scenarioItemsConfiguration",
                column: "request_itemId_request_item",
                principalTable: "requestsItem",
                principalColumn: "Id_request_item");

            migrationBuilder.AddForeignKey(
                name: "FK_scenarioItemsConfiguration_scenario_scenarioId_scenario",
                table: "scenarioItemsConfiguration",
                column: "scenarioId_scenario",
                principalTable: "scenario",
                principalColumn: "Id_scenario");
        }
    }
}
