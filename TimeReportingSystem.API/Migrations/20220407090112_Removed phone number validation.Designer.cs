﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeReportingSystem.API.Model;

namespace TimeReportingSystem.API.Migrations
{
    [DbContext(typeof(TimeReportDbContext))]
    [Migration("20220407090112_Removed phone number validation")]
    partial class Removedphonenumbervalidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TimeReportingSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Email = "h.hannasson@company.com",
                            FirstName = "Hanna",
                            LastName = "Hannasson",
                            PhoneNumber = "0701231234",
                            Role = "Fronend developer",
                            StartDate = new DateTime(2019, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 2,
                            Email = "m.malinsson@company.com",
                            FirstName = "Malin",
                            LastName = "Malinsson",
                            PhoneNumber = "0701232345",
                            Role = "Frontend developer",
                            StartDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 3,
                            Email = "d.dagsson@company.com",
                            FirstName = "Dag",
                            LastName = "Dagsson",
                            PhoneNumber = "0701234567",
                            Role = "Frontend developer",
                            StartDate = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 4,
                            Email = "m.monasson@company.com",
                            FirstName = "Mona",
                            LastName = "Monasson",
                            PhoneNumber = "0701233456",
                            Role = "Backend developer",
                            StartDate = new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 5,
                            Email = "a.axelsson@company.com",
                            FirstName = "Axel",
                            LastName = "Axelsson",
                            PhoneNumber = "0701235678",
                            Role = "Backend developer",
                            StartDate = new DateTime(2018, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 6,
                            Email = "s.sivsson@company.com",
                            FirstName = "Siv",
                            LastName = "Sivsson",
                            PhoneNumber = "0701236789",
                            Role = "QA",
                            StartDate = new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TimeReportingSystem.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            ProjectName = "World of Warcraft"
                        },
                        new
                        {
                            ProjectId = 2,
                            ProjectName = "Hearthstone"
                        },
                        new
                        {
                            ProjectId = 3,
                            ProjectName = "Overwatch 2"
                        },
                        new
                        {
                            ProjectId = 4,
                            ProjectName = "Starcraft 4"
                        },
                        new
                        {
                            ProjectId = 5,
                            ProjectName = "Diablo"
                        });
                });

            modelBuilder.Entity("TimeReportingSystem.Models.TimeReport", b =>
                {
                    b.Property<int>("TimeReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("WorkedHours")
                        .HasColumnType("int");

                    b.HasKey("TimeReportId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("TimeReports");

                    b.HasData(
                        new
                        {
                            TimeReportId = 1,
                            Date = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            Note = "Bug fixing",
                            ProjectId = 1,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 2,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            Note = "Maintenance",
                            ProjectId = 1,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 3,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            Note = "Additional help with bug fixing",
                            ProjectId = 2,
                            WorkedHours = 1
                        },
                        new
                        {
                            TimeReportId = 4,
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            Note = "Maintenance and bug fixing",
                            ProjectId = 1,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 5,
                            Date = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            Note = "Maintenance",
                            ProjectId = 1,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 6,
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            Note = "Maintenance",
                            ProjectId = 1,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 7,
                            Date = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            Note = "Maintenance",
                            ProjectId = 2,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 8,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            Note = "Bug fixing",
                            ProjectId = 2,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 9,
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            Note = "Development",
                            ProjectId = 3,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 10,
                            Date = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            Note = "Development",
                            ProjectId = 3,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 11,
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            Note = "Development",
                            ProjectId = 3,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 12,
                            Date = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 3,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 13,
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 3,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 6
                        },
                        new
                        {
                            TimeReportId = 14,
                            Date = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 3,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 15,
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 3,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 7
                        },
                        new
                        {
                            TimeReportId = 16,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 4,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 17,
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 4,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 18,
                            Date = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 4,
                            Note = "Development",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 19,
                            Date = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            Note = "Maintenance",
                            ProjectId = 5,
                            WorkedHours = 2
                        },
                        new
                        {
                            TimeReportId = 20,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            Note = "Maintenance",
                            ProjectId = 5,
                            WorkedHours = 2
                        },
                        new
                        {
                            TimeReportId = 21,
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            Note = "Maintenance",
                            ProjectId = 5,
                            WorkedHours = 2
                        },
                        new
                        {
                            TimeReportId = 22,
                            Date = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            Note = "Maintenance",
                            ProjectId = 5,
                            WorkedHours = 2
                        },
                        new
                        {
                            TimeReportId = 23,
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            Note = "Maintenance",
                            ProjectId = 5,
                            WorkedHours = 2
                        },
                        new
                        {
                            TimeReportId = 24,
                            Date = new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 6,
                            Note = "Testing",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 25,
                            Date = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 6,
                            Note = "Testing",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 26,
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 6,
                            Note = "Testing",
                            ProjectId = 3,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 27,
                            Date = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 6,
                            Note = "Testing",
                            ProjectId = 4,
                            WorkedHours = 8
                        },
                        new
                        {
                            TimeReportId = 28,
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 6,
                            Note = "Testing",
                            ProjectId = 3,
                            WorkedHours = 8
                        });
                });

            modelBuilder.Entity("TimeReportingSystem.Models.TimeReport", b =>
                {
                    b.HasOne("TimeReportingSystem.Models.Employee", "Employee")
                        .WithMany("TimeReports")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TimeReportingSystem.Models.Project", "Project")
                        .WithMany("TimeReports")
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
