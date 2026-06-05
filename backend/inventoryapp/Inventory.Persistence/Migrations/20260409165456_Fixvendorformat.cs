using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixvendorformat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "DefaultVendor",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "LeadTimeDays",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "OrderUnit",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "TaxExempt",
                table: "VendorItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "DefaultVendor",
                table: "VendorItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LeadTimeDays",
                table: "VendorItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderUnit",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TaxExempt",
                table: "VendorItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
