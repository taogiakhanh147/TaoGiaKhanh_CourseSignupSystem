using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSignupSystemCode.Migrations
{
    public partial class DBInit11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Course");

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseEndDate",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseStartDate",
                table: "Course",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseEndDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseStartDate",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
