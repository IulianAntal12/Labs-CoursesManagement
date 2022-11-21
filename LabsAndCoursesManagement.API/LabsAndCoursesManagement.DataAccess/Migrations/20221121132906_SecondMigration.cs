using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabsAndCoursesManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTeacher_Lab_LabId",
                table: "LabTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LabTeacher_Teacher_TeachersId",
                table: "LabTeacher");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "LabTeacher",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "LabId",
                table: "LabTeacher",
                newName: "LabsId");

            migrationBuilder.RenameIndex(
                name: "IX_LabTeacher_TeachersId",
                table: "LabTeacher",
                newName: "IX_LabTeacher_TeacherId");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Lab",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_LabTeacher_Lab_LabsId",
                table: "LabTeacher",
                column: "LabsId",
                principalTable: "Lab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabTeacher_Teacher_TeacherId",
                table: "LabTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTeacher_Lab_LabsId",
                table: "LabTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LabTeacher_Teacher_TeacherId",
                table: "LabTeacher");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Lab");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "LabTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameColumn(
                name: "LabsId",
                table: "LabTeacher",
                newName: "LabId");

            migrationBuilder.RenameIndex(
                name: "IX_LabTeacher_TeacherId",
                table: "LabTeacher",
                newName: "IX_LabTeacher_TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTeacher_Lab_LabId",
                table: "LabTeacher",
                column: "LabId",
                principalTable: "Lab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabTeacher_Teacher_TeachersId",
                table: "LabTeacher",
                column: "TeachersId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
