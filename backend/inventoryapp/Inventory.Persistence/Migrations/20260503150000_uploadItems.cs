using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class uploadItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "ItemDocument",
                newName: "ItemDocument",
                newSchema: "dbo");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                schema: "dbo",
                table: "ItemDocument",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "dbo",
                table: "ItemDocument",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                schema: "dbo",
                table: "ItemDocument");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "ItemDocument");

            migrationBuilder.RenameTable(
                name: "ItemDocument",
                schema: "dbo",
                newName: "ItemDocument");
        }
    }
}
