using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Item : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxQuantity",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Items",
                newName: "OrderUnit");

            migrationBuilder.AddColumn<bool>(
                name: "AttachToAsset",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CommodityCodeDesc",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommodityGroupDesc",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ConditionEnabled",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "InspectOnReceipt",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsKit",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSparePart",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IssueUnit",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemCode",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemSet",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LotType",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxQty",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meter",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeterDesc",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeterGroup",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeterGroupDesc",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Msds",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ReceiptTolerance",
                table: "Items",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TaxExempt",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Alternates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    al_item = table.Column<int>(type: "int", nullable: false),
                    al_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    al_commodityGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    al_commodityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    al_rotating = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alternates_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alternates_Items_al_item",
                        column: x => x.al_item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemAssemblies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentItemId = table.Column<int>(type: "int", nullable: false),
                    ChildItemId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAssemblies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemAssemblies_Items_ChildItemId",
                        column: x => x.ChildItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemAssemblies_Items_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ConditionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemConditions_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreroomItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Storeroom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DefaultBin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreroomItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreroomItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastOrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeadTimeDays = table.Column<int>(type: "int", nullable: true),
                    TaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    DefaultVendor = table.Column<bool>(type: "bit", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternates_al_item",
                table: "Alternates",
                column: "al_item");

            migrationBuilder.CreateIndex(
                name: "IX_Alternates_ItemId",
                table: "Alternates",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAssemblies_ChildItemId",
                table: "ItemAssemblies",
                column: "ChildItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAssemblies_ParentItemId",
                table: "ItemAssemblies",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemConditions_ItemId",
                table: "ItemConditions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreroomItems_ItemId",
                table: "StoreroomItems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternates");

            migrationBuilder.DropTable(
                name: "ItemAssemblies");

            migrationBuilder.DropTable(
                name: "ItemConditions");

            migrationBuilder.DropTable(
                name: "StoreroomItems");

            migrationBuilder.DropTable(
                name: "VendorItems");

            migrationBuilder.DropColumn(
                name: "AttachToAsset",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CommodityCodeDesc",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CommodityGroupDesc",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ConditionEnabled",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "InspectOnReceipt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsKit",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsSparePart",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IssueUnit",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemSet",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LotType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MaxQty",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Meter",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MeterDesc",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MeterGroup",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MeterGroupDesc",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Msds",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ReceiptTolerance",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TaxExempt",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "OrderUnit",
                table: "Items",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "MaxQuantity",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
