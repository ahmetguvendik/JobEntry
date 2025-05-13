using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_13052025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ApplyJobs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ApplyJobs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_AppUserId",
                table: "ApplyJobs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_AspNetUsers_AppUserId",
                table: "ApplyJobs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_AspNetUsers_AppUserId",
                table: "ApplyJobs");

            migrationBuilder.DropIndex(
                name: "IX_ApplyJobs_AppUserId",
                table: "ApplyJobs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ApplyJobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApplyJobs");
        }
    }
}
