using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabsAndCoursesManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Labs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Homework",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Homework");

            migrationBuilder.DropColumn(
                name: "Tenant",
                table: "Courses");
        }
    }
}
