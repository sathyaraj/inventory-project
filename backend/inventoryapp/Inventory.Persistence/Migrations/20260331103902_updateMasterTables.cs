using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateMasterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterdetails_Masters_MasterId",
                table: "Masterdetails");

            migrationBuilder.DropIndex(
                name: "IX_Masterdetails_MasterId",
                table: "Masterdetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Masterdetails_MasterId",
                table: "Masterdetails",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterdetails_Masters_MasterId",
                table: "Masterdetails",
                column: "MasterId",
                principalTable: "Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
