using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabsAndCoursesManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lab_Teacher_TeacherId",
                table: "Lab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lab",
                table: "Lab");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Lab",
                newName: "Labs");

            migrationBuilder.RenameIndex(
                name: "IX_Lab_TeacherId",
                table: "Labs",
                newName: "IX_Labs_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labs",
                table: "Labs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Labs_Teachers_TeacherId",
                table: "Labs",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labs_Teachers_TeacherId",
                table: "Labs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labs",
                table: "Labs");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Labs",
                newName: "Lab");

            migrationBuilder.RenameIndex(
                name: "IX_Labs_TeacherId",
                table: "Lab",
                newName: "IX_Lab_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lab",
                table: "Lab",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lab_Teacher_TeacherId",
                table: "Lab",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
