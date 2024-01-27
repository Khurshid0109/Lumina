using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumina.Data.Migrations
{
    /// <inheritdoc />
    public partial class StatusAddedForCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartedDay",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudyCenters_ParentId",
                table: "StudyCenters",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyCenters_StudyCenters_ParentId",
                table: "StudyCenters",
                column: "ParentId",
                principalTable: "StudyCenters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyCenters_StudyCenters_ParentId",
                table: "StudyCenters");

            migrationBuilder.DropIndex(
                name: "IX_StudyCenters_ParentId",
                table: "StudyCenters");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedDay",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
