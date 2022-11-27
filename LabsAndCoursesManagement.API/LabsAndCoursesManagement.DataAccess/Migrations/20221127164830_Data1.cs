using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabsAndCoursesManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Data1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LabId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_LabId",
                table: "Students",
                column: "LabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Labs_LabId",
                table: "Students",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Labs_LabId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LabId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LabId",
                table: "Students");
        }
    }
}
