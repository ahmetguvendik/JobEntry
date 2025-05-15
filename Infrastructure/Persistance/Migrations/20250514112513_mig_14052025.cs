using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_14052025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AppUserId",
                table: "Companies",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_AppUserId",
                table: "Companies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_AppUserId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AppUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Companies");
        }
    }
}
