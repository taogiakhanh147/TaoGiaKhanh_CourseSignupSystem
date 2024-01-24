using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseSignupSystemCode.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourseEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ScoreType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreScale = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TuitionType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuitionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfStudent = table.Column<int>(type: "int", nullable: true),
                    Fee = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCourse = table.Column<int>(type: "int", nullable: false),
                    IDFaculty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Class_Course_IDCourse",
                        column: x => x.IDCourse,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Faculty_IDFaculty",
                        column: x => x.IDFaculty,
                        principalTable: "Faculty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ịmage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Role_IDRole",
                        column: x => x.IDRole,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryPercent = table.Column<int>(type: "int", nullable: true),
                    Allowance = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryNet = table.Column<int>(type: "int", nullable: true),
                    IDTeacher = table.Column<int>(type: "int", nullable: false),
                    IDClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salary_Class_IDClass",
                        column: x => x.IDClass,
                        principalTable: "Class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleAndFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameOfParent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDRole = table.Column<int>(type: "int", nullable: false),
                    IDClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Class_IDClass",
                        column: x => x.IDClass,
                        principalTable: "Class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Role_IDRole",
                        column: x => x.IDRole,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDDepartment = table.Column<int>(type: "int", nullable: false),
                    IDClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subject_Class_IDClass",
                        column: x => x.IDClass,
                        principalTable: "Class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Department_IDDepartment",
                        column: x => x.IDDepartment,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectOfTeachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDDepartment = table.Column<int>(type: "int", nullable: false),
                    IDClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectOfTeachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubjectOfTeachers_Class_IDClass",
                        column: x => x.IDClass,
                        principalTable: "Class",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectOfTeachers_Department_IDDepartment",
                        column: x => x.IDDepartment,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<float>(type: "real", nullable: true),
                    IDSubject = table.Column<int>(type: "int", nullable: false),
                    IDScoreType = table.Column<int>(type: "int", nullable: false),
                    IDStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Result_Student_IDStudent",
                        column: x => x.IDStudent,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDSubject = table.Column<int>(type: "int", nullable: false),
                    IDStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedule_Student_IDStudent",
                        column: x => x.IDStudent,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tuition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuitionFee = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Surcharge = table.Column<int>(type: "int", nullable: true),
                    TotalTuition = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDClass = table.Column<int>(type: "int", nullable: false),
                    IDStudent = table.Column<int>(type: "int", nullable: false),
                    IDTuitionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tuition_Student_IDStudent",
                        column: x => x.IDStudent,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tuition_TuitionType_IDTuitionType",
                        column: x => x.IDTuitionType,
                        principalTable: "TuitionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreTypeSubject",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradingColumn = table.Column<int>(type: "int", nullable: true),
                    RequiredGradeColumns = table.Column<int>(type: "int", nullable: true),
                    IDCourse = table.Column<int>(type: "int", nullable: false),
                    IDSubject = table.Column<int>(type: "int", nullable: false),
                    IDScoreType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreTypeSubject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScoreTypeSubject_ScoreType_IDScoreType",
                        column: x => x.IDScoreType,
                        principalTable: "ScoreType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreTypeSubject_Subject_IDSubject",
                        column: x => x.IDSubject,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleAndFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartTimeSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDSubject = table.Column<int>(type: "int", nullable: false),
                    IDRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teacher_Role_IDRole",
                        column: x => x.IDRole,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_SubjectOfTeachers_IDSubject",
                        column: x => x.IDSubject,
                        principalTable: "SubjectOfTeachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingSchedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeachTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeachDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDClass = table.Column<int>(type: "int", nullable: false),
                    IDSubject = table.Column<int>(type: "int", nullable: false),
                    IDTeacher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingSchedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeachingSchedule_Teacher_IDTeacher",
                        column: x => x.IDTeacher,
                        principalTable: "Teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_IDCourse",
                table: "Class",
                column: "IDCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Class_IDFaculty",
                table: "Class",
                column: "IDFaculty");

            migrationBuilder.CreateIndex(
                name: "IX_Result_IDStudent",
                table: "Result",
                column: "IDStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_IDClass",
                table: "Salary",
                column: "IDClass");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_IDStudent",
                table: "Schedule",
                column: "IDStudent");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreTypeSubject_IDScoreType",
                table: "ScoreTypeSubject",
                column: "IDScoreType");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreTypeSubject_IDSubject",
                table: "ScoreTypeSubject",
                column: "IDSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IDClass",
                table: "Student",
                column: "IDClass");

            migrationBuilder.CreateIndex(
                name: "IX_Student_IDRole",
                table: "Student",
                column: "IDRole");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IDClass",
                table: "Subject",
                column: "IDClass");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IDDepartment",
                table: "Subject",
                column: "IDDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectOfTeachers_IDClass",
                table: "SubjectOfTeachers",
                column: "IDClass");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectOfTeachers_IDDepartment",
                table: "SubjectOfTeachers",
                column: "IDDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_IDRole",
                table: "Teacher",
                column: "IDRole");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_IDSubject",
                table: "Teacher",
                column: "IDSubject");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSchedule_IDTeacher",
                table: "TeachingSchedule",
                column: "IDTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Tuition_IDStudent",
                table: "Tuition",
                column: "IDStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Tuition_IDTuitionType",
                table: "Tuition",
                column: "IDTuitionType");

            migrationBuilder.CreateIndex(
                name: "IX_User_IDRole",
                table: "User",
                column: "IDRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ScoreTypeSubject");

            migrationBuilder.DropTable(
                name: "TeachingSchedule");

            migrationBuilder.DropTable(
                name: "Tuition");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ScoreType");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TuitionType");

            migrationBuilder.DropTable(
                name: "SubjectOfTeachers");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
