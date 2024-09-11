using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApproverRequest",
                columns: table => new
                {
                    id_approverrequest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApproverRequest", x => x.id_approverrequest);
                    table.ForeignKey(
                        name: "FK_ApproverRequest_request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "request",
                        principalColumn: "RequestNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApproverRequest_RequestId",
                table: "ApproverRequest",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApproverRequest");
        }
    }
}
