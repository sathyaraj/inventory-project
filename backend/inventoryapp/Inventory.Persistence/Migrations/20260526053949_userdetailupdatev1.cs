using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userdetailupdatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserDetails",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "UserDetails",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserDetails");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserDetails",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "UserDetails",
                newName: "ConfirmPassword");
        }
    }
}
