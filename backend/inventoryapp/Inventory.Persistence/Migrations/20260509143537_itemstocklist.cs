using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class itemstocklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "Stocklists",
                newName: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocklists_ItemId",
                table: "Stocklists",
                column: "ItemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocklists_ItemId",
                table: "Stocklists");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Stocklists",
                newName: "itemId");
        }
    }
}
