using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ServiceItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatalogNumber",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "LastOrderDate",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "LastPrice",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "VendorItems");

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

            migrationBuilder.AddColumn<bool>(
                name: "TaxExempt",
                table: "VendorItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ItemSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Itemid = table.Column<int>(type: "int", nullable: false),
                    SpcCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpcItem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSpecification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItemOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceItemId = table.Column<int>(type: "int", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GLAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptTolerance = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItemOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityGroupDes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommodityCodeDes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    Prorate = table.Column<bool>(type: "bit", nullable: false),
                    InspectionRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSpecificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSpecificationId = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datatype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlphaValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSpecificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSpecificationDetails_ItemSpecification_ItemSpecificationId",
                        column: x => x.ItemSpecificationId,
                        principalTable: "ItemSpecification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSpecificationDetails_ItemSpecificationId",
                table: "ItemSpecificationDetails",
                column: "ItemSpecificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSpecificationDetails");

            migrationBuilder.DropTable(
                name: "ServiceItemOrganizations");

            migrationBuilder.DropTable(
                name: "ServiceItems");

            migrationBuilder.DropTable(
                name: "ItemSpecification");

            migrationBuilder.DropColumn(
                name: "DefaultVendor",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "LeadTimeDays",
                table: "VendorItems");

            migrationBuilder.DropColumn(
                name: "TaxExempt",
                table: "VendorItems");

            migrationBuilder.AddColumn<string>(
                name: "CatalogNumber",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOrderDate",
                table: "VendorItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LastPrice",
                table: "VendorItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "VendorItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
