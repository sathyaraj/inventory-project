using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changefieldenddate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manudate",
                table: "Items",
                newName: "WarEndDate");

            migrationBuilder.RenameColumn(
                name: "Enddate",
                table: "Items",
                newName: "ManufactureDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WarEndDate",
                table: "Items",
                newName: "Manudate");

            migrationBuilder.RenameColumn(
                name: "ManufactureDate",
                table: "Items",
                newName: "Enddate");
        }
    }
}
