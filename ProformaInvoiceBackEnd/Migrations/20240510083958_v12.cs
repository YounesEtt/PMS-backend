using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level",
                table: "scenarioItemsConfiguration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "scenarioItemsConfiguration",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
