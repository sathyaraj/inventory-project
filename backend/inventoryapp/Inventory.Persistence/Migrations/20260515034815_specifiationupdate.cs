using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class specifiationupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlphaValue",
                table: "ItemSpecificationDetails");

            migrationBuilder.DropColumn(
                name: "Datatype",
                table: "ItemSpecificationDetails");

            migrationBuilder.RenameColumn(
                name: "NumericValue",
                table: "ItemSpecificationDetails",
                newName: "value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "ItemSpecificationDetails",
                newName: "NumericValue");

            migrationBuilder.AddColumn<string>(
                name: "AlphaValue",
                table: "ItemSpecificationDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Datatype",
                table: "ItemSpecificationDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
