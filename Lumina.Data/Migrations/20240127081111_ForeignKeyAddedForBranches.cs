using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumina.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAddedForBranches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthorizedForTeaching",
                table: "Teachers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "StudyCenters",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthorizedForTeaching",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "StudyCenters");
        }
    }
}
