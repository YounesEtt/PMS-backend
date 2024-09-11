using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.AddColumn<int>(
                name: "DepartementId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "approver",
                columns: table => new
                {
                    id_approver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approver", x => x.id_approver);
                });

            migrationBuilder.CreateTable(
                name: "plant",
                columns: table => new
                {
                    Id_plant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_plant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plant", x => x.Id_plant);
                });

            migrationBuilder.CreateTable(
                name: "requestsItem",
                columns: table => new
                {
                    Id_request_item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNumber = table.Column<int>(type: "int", nullable: false),
                    PN = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_Center = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DHL_Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoicesTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scenario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    incoterm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestsItem", x => x.Id_request_item);
                });

            migrationBuilder.CreateTable(
                name: "scenario",
                columns: table => new
                {
                    Id_scenario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenario", x => x.Id_scenario);
                    table.ForeignKey(
                        name: "FK_scenario_approver_approverId",
                        column: x => x.approverId,
                        principalTable: "approver",
                        principalColumn: "id_approver",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departement",
                columns: table => new
                {
                    Id_departement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departement", x => x.Id_departement);
                    table.ForeignKey(
                        name: "FK_departement_plant_plantId",
                        column: x => x.plantId,
                        principalTable: "plant",
                        principalColumn: "Id_plant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "request",
                columns: table => new
                {
                    Id_request = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNumber = table.Column<int>(type: "int", nullable: false),
                    PN = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_Center = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DHL_Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoicesTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scenario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    incoterm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    scenarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request", x => x.Id_request);
                    table.ForeignKey(
                        name: "FK_request_scenario_scenarioId",
                        column: x => x.scenarioId,
                        principalTable: "scenario",
                        principalColumn: "Id_scenario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_request_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scenarioItemsConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_scenario = table.Column<int>(type: "int", nullable: false),
                    Id_request_item = table.Column<int>(type: "int", nullable: false),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    request_itemId_request_item = table.Column<int>(type: "int", nullable: true),
                    scenarioId_scenario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenarioItemsConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scenarioItemsConfiguration_requestsItem_Id_request_item",
                        column: x => x.Id_request_item,
                        principalTable: "requestsItem",
                        principalColumn: "Id_request_item",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scenarioItemsConfiguration_requestsItem_request_itemId_request_item",
                        column: x => x.request_itemId_request_item,
                        principalTable: "requestsItem",
                        principalColumn: "Id_request_item");
                    table.ForeignKey(
                        name: "FK_scenarioItemsConfiguration_scenario_Id_scenario",
                        column: x => x.Id_scenario,
                        principalTable: "scenario",
                        principalColumn: "Id_scenario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scenarioItemsConfiguration_scenario_scenarioId_scenario",
                        column: x => x.scenarioId_scenario,
                        principalTable: "scenario",
                        principalColumn: "Id_scenario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_DepartementId",
                table: "user",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_departement_plantId",
                table: "departement",
                column: "plantId");

            migrationBuilder.CreateIndex(
                name: "IX_request_scenarioId",
                table: "request",
                column: "scenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_request_userId",
                table: "request",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_scenario_approverId",
                table: "scenario",
                column: "approverId");

            migrationBuilder.CreateIndex(
                name: "IX_scenarioItemsConfiguration_Id_request_item",
                table: "scenarioItemsConfiguration",
                column: "Id_request_item");

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
                name: "FK_user_departement_DepartementId",
                table: "user",
                column: "DepartementId",
                principalTable: "departement",
                principalColumn: "Id_departement",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_departement_DepartementId",
                table: "user");

            migrationBuilder.DropTable(
                name: "departement");

            migrationBuilder.DropTable(
                name: "request");

            migrationBuilder.DropTable(
                name: "scenarioItemsConfiguration");

            migrationBuilder.DropTable(
                name: "plant");

            migrationBuilder.DropTable(
                name: "requestsItem");

            migrationBuilder.DropTable(
                name: "scenario");

            migrationBuilder.DropTable(
                name: "approver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_DepartementId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }
    }
}
