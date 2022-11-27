using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabsAndCoursesManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "LabStudent",
                columns: table => new
                {
                    LabsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabStudent", x => new { x.LabsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LabStudent_Labs_LabsId",
                        column: x => x.LabsId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabStudent_StudentsId",
                table: "LabStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabStudent");

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
    }
}
