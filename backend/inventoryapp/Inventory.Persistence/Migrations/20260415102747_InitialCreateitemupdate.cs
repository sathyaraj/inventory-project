using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateitemupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxQty",
                table: "Items",
                newName: "serialno");

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "enddate",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "manudate",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "manuft",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "Items",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "enddate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "manudate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "manuft",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "model",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "period",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "serialno",
                table: "Items",
                newName: "MaxQty");
        }
    }
}
