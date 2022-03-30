using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeReportingSystem.API.Migrations
{
    public partial class Initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    WorkedHours = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportId);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "EndDate", "FirstName", "LastName", "PhoneNumber", "Role", "StartDate" },
                values: new object[,]
                {
                    { 1, "h.hannasson@company.com", null, "Hanna", "Hannasson", "0701231234", "Fronend developer", new DateTime(2019, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "m.malinsson@company.com", null, "Malin", "Malinsson", "0701232345", "Frontend developer", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "d.dagsson@company.com", null, "Dag", "Dagsson", "0701234567", "Frontend developer", new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "m.monasson@company.com", null, "Mona", "Monasson", "0701233456", "Backend developer", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "a.axelsson@company.com", null, "Axel", "Axelsson", "0701235678", "Backend developer", new DateTime(2018, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "s.sivsson@company.com", null, "Siv", "Sivsson", "0701236789", "QA", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ProjectName" },
                values: new object[,]
                {
                    { 1, "World of Warcraft" },
                    { 2, "Hearthstone" },
                    { 3, "Overwatch 2" },
                    { 4, "Starcraft 4" },
                    { 5, "Diablo" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "Date", "EmployeeId", "Note", "ProjectId", "WorkedHours" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bug fixing", 1, 8 },
                    { 21, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Maintenance", 5, 2 },
                    { 20, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Maintenance", 5, 2 },
                    { 19, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Maintenance", 5, 2 },
                    { 27, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Testing", 4, 8 },
                    { 25, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Testing", 4, 8 },
                    { 24, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Testing", 4, 8 },
                    { 18, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Development", 4, 8 },
                    { 17, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Development", 4, 8 },
                    { 16, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Development", 4, 8 },
                    { 15, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Development", 4, 7 },
                    { 14, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Development", 4, 8 },
                    { 13, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Development", 4, 6 },
                    { 12, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Development", 4, 8 },
                    { 28, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Testing", 3, 8 },
                    { 26, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Testing", 3, 8 },
                    { 11, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Development", 3, 8 },
                    { 10, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Development", 3, 8 },
                    { 9, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Development", 3, 8 },
                    { 8, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Bug fixing", 2, 7 },
                    { 7, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Maintenance", 2, 7 },
                    { 3, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Additional help with bug fixing", 2, 1 },
                    { 6, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maintenance", 1, 7 },
                    { 5, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maintenance", 1, 7 },
                    { 4, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maintenance and bug fixing", 1, 7 },
                    { 2, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maintenance", 1, 7 },
                    { 22, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Maintenance", 5, 2 },
                    { 23, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Maintenance", 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
