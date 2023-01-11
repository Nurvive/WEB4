using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_workers_directorid",
                table: "projects");

            migrationBuilder.DropTable(
                name: "projectsWorkers");

            migrationBuilder.DropIndex(
                name: "IX_projects_directorid",
                table: "projects");

            migrationBuilder.RenameColumn(
                name: "directorid",
                table: "projects",
                newName: "directorId");

            migrationBuilder.AddColumn<Guid>(
                name: "Workerid",
                table: "projects",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_projects_Workerid",
                table: "projects",
                column: "Workerid");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_workers_Workerid",
                table: "projects",
                column: "Workerid",
                principalTable: "workers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_workers_Workerid",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_Workerid",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Workerid",
                table: "projects");

            migrationBuilder.RenameColumn(
                name: "directorId",
                table: "projects",
                newName: "directorid");

            migrationBuilder.CreateTable(
                name: "projectsWorkers",
                columns: table => new
                {
                    WorkerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectsWorkers", x => new { x.WorkerId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_projectsWorkers_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectsWorkers_workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "workers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_projects_directorid",
                table: "projects",
                column: "directorid");

            migrationBuilder.CreateIndex(
                name: "IX_projectsWorkers_ProjectId",
                table: "projectsWorkers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_workers_directorid",
                table: "projects",
                column: "directorid",
                principalTable: "workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
