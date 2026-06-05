using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatevendortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultVendor",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "VendorItems");

            migrationBuilder.RenameColumn(
                name: "TaxExempt",
                table: "VendorItems",
                newName: "taxexempt");

            migrationBuilder.RenameColumn(
                name: "VendorName",
                table: "VendorItems",
                newName: "Pono");

            migrationBuilder.RenameColumn(
                name: "Site",
                table: "VendorItems",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "LeadTimeDays",
                table: "VendorItems",
                newName: "leadtimedelay");

            migrationBuilder.AddColumn<int>(
                name: "Invoiceno",
                table: "VendorItems",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoiceno",
                table: "VendorItems");

            migrationBuilder.RenameColumn(
                name: "taxexempt",
                table: "VendorItems",
                newName: "TaxExempt");

            migrationBuilder.RenameColumn(
                name: "leadtimedelay",
                table: "VendorItems",
                newName: "LeadTimeDays");

            migrationBuilder.RenameColumn(
                name: "Pono",
                table: "VendorItems",
                newName: "VendorName");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "VendorItems",
                newName: "Site");

            migrationBuilder.AddColumn<bool>(
                name: "DefaultVendor",
                table: "VendorItems",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
