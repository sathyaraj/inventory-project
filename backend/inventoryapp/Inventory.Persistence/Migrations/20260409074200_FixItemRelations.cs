using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixItemRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternates_Items_ItemId",
                table: "Alternates");

            migrationBuilder.DropForeignKey(
                name: "FK_Alternates_Items_al_item",
                table: "Alternates");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAssemblies_Items_ChildItemId",
                table: "ItemAssemblies");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemAssemblies_Items_ParentItemId",
                table: "ItemAssemblies");

            migrationBuilder.DropIndex(
                name: "IX_ItemAssemblies_ChildItemId",
                table: "ItemAssemblies");

            migrationBuilder.DropIndex(
                name: "IX_ItemAssemblies_ParentItemId",
                table: "ItemAssemblies");

            migrationBuilder.DropIndex(
                name: "IX_Alternates_al_item",
                table: "Alternates");

            migrationBuilder.AlterColumn<string>(
                name: "al_item",
                table: "Alternates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternates_Items_ItemId",
                table: "Alternates",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternates_Items_ItemId",
                table: "Alternates");

            migrationBuilder.AlterColumn<int>(
                name: "al_item",
                table: "Alternates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAssemblies_ChildItemId",
                table: "ItemAssemblies",
                column: "ChildItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAssemblies_ParentItemId",
                table: "ItemAssemblies",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternates_al_item",
                table: "Alternates",
                column: "al_item");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternates_Items_ItemId",
                table: "Alternates",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alternates_Items_al_item",
                table: "Alternates",
                column: "al_item",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAssemblies_Items_ChildItemId",
                table: "ItemAssemblies",
                column: "ChildItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemAssemblies_Items_ParentItemId",
                table: "ItemAssemblies",
                column: "ParentItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
