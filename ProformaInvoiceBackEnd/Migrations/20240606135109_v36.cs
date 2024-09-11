using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "username",
                table: "ApproverRequest");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "ApproverRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "classe",
                table: "ApproverRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "ApproverRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "classe",
                table: "ApproverRequest");

            migrationBuilder.DropColumn(
                name: "role",
                table: "ApproverRequest");


            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "ApproverRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "ApproverRequest",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
