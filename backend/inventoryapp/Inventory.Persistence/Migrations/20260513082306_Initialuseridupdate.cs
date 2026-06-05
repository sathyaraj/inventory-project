using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialuseridupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "VendorItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "StoreroomItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "Stocklists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "StockCancels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ServiceItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ServiceItemOrganizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ItemSpecificationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ItemSpecification",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ItemList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                schema: "dbo",
                table: "ItemDocument",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ItemConditions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ItemAssemblyDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "ItemAssemblies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "DocumentDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UseId",
                table: "Alternates",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseId",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "StoreroomItems");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Stocklists");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "StockCancels");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ServiceItems");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ServiceItemOrganizations");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ItemSpecificationDetails");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ItemSpecification");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ItemList");

            migrationBuilder.DropColumn(
                name: "UseId",
                schema: "dbo",
                table: "ItemDocument");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ItemConditions");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ItemAssemblyDetails");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "ItemAssemblies");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "DocumentDetails");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Alternates");
        }
    }
}
