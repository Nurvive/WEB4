using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "projects",
                table: "workers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "projects",
                table: "workers");

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
    }
}
