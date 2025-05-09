using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobEntry.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_09052025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NameSurname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: true),
                    CvFilePath = table.Column<string>(type: "text", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    JobId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobId",
                table: "ApplyJobs",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobs");
        }
    }
}
