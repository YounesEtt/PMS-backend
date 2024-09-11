﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApproverRequest_request_RequestId",
                table: "ApproverRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_ApproverRequest_request_RequestId",
                table: "ApproverRequest",
                column: "RequestId",
                principalTable: "request",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApproverRequest_request_RequestId",
                table: "ApproverRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_ApproverRequest_request_RequestId",
                table: "ApproverRequest",
                column: "RequestId",
                principalTable: "request",
                principalColumn: "RequestNumber");
        }
    }
}
