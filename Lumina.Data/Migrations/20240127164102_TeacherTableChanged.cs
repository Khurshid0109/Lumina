using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lumina.Data.Migrations
{
    /// <inheritdoc />
    public partial class TeacherTableChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudyCenterTeacher",
                columns: table => new
                {
                    StudyCentersId = table.Column<long>(type: "bigint", nullable: false),
                    TeachersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCenterTeacher", x => new { x.StudyCentersId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_StudyCenterTeacher_StudyCenters_StudyCentersId",
                        column: x => x.StudyCentersId,
                        principalTable: "StudyCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyCenterTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyCenterTeacher_TeachersId",
                table: "StudyCenterTeacher",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyCenterTeacher");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");
        }
    }
}
