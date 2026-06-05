using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedToItemAssembly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildItemId",
                table: "ItemAssemblies");

            migrationBuilder.DropColumn(
                name: "ParentItemId",
                table: "ItemAssemblies");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ItemAssemblies");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ItemAssemblies",
                newName: "TopLevelItem");

            migrationBuilder.AddColumn<string>(
                name: "BelongsTo",
                table: "ItemAssemblies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentLevel",
                table: "ItemAssemblies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentLevelCode",
                table: "ItemAssemblies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TopLevelCode",
                table: "ItemAssemblies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ItemAssemblyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssemblyId = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAssemblyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemAssemblyDetails_ItemAssemblies_AssemblyId",
                        column: x => x.AssemblyId,
                        principalTable: "ItemAssemblies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemAssemblyDetails_AssemblyId",
                table: "ItemAssemblyDetails",
                column: "AssemblyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAssemblyDetails");

            migrationBuilder.DropColumn(
                name: "BelongsTo",
                table: "ItemAssemblies");

            migrationBuilder.DropColumn(
                name: "CurrentLevel",
                table: "ItemAssemblies");

            migrationBuilder.DropColumn(
                name: "CurrentLevelCode",
                table: "ItemAssemblies");

            migrationBuilder.DropColumn(
                name: "TopLevelCode",
                table: "ItemAssemblies");

            migrationBuilder.RenameColumn(
                name: "TopLevelItem",
                table: "ItemAssemblies",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "ChildItemId",
                table: "ItemAssemblies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentItemId",
                table: "ItemAssemblies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ItemAssemblies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
