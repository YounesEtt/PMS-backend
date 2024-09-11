using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_request_scenario_scenarioId",
                table: "request");

            migrationBuilder.DropForeignKey(
                name: "FK_request_user_userId",
                table: "request");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "shipId",
                table: "request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "scenarioId",
                table: "request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_request_scenario_scenarioId",
                table: "request",
                column: "scenarioId",
                principalTable: "scenario",
                principalColumn: "Id_scenario");

            migrationBuilder.AddForeignKey(
                name: "FK_request_user_userId",
                table: "request",
                column: "userId",
                principalTable: "user",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_request_scenario_scenarioId",
                table: "request");

            migrationBuilder.DropForeignKey(
                name: "FK_request_user_userId",
                table: "request");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "shipId",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "scenarioId",
                table: "request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_request_scenario_scenarioId",
                table: "request",
                column: "scenarioId",
                principalTable: "scenario",
                principalColumn: "Id_scenario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_request_user_userId",
                table: "request",
                column: "userId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
