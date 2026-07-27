using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectIT3045.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollegeCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProfessorFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorLast = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CollegeCourses",
                columns: new[] { "Id", "CourseName", "EndDate", "ProfessorFirst", "ProfessorLast", "StartDate", "Subject" },
                values: new object[,]
                {
                    { 1, "Contemporary Programming", new DateOnly(2026, 8, 8), "Dyllon", "Dekok", new DateOnly(2026, 5, 11), "IT" },
                    { 2, "Applied Statistics for Human Services", new DateOnly(2026, 8, 8), "Samuel", "Adabla", new DateOnly(2026, 5, 11), "Math" },
                    { 3, "Human Computer Interaction", new DateOnly(2026, 8, 8), "Theodore", "Langdon", new DateOnly(2026, 5, 11), "IT" },
                    { 4, "Web Game Development", new DateOnly(2026, 8, 8), "Andrew", "Lively", new DateOnly(2026, 5, 11), "IT" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteBooks",
                columns: new[] { "Id", "Author", "Genre", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "Fiction", new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 2, "Harper Lee", "Fiction", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird" },
                    { 3, "George Orwell", "Dystopian", new DateTime(1948, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Breed", "DateOfBirth", "Name", "Species" },
                values: new object[,]
                {
                    { 1, "Husky", null, "Jacob", "Dog" },
                    { 2, "Chihuahua", null, "Brandy", "Dog" },
                    { 3, "DSH", new DateOnly(2023, 5, 20), "Dice", "cat" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "CollegeProgram", "DateOfBirth", "FirstName", "LastName", "YearInProgram" },
                values: new object[,]
                {
                    { 1, "Information Technology", new DateTime(2003, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaylah", "Hammond", "Senior" },
                    { 2, "Information Technology", new DateTime(2006, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoe", "Aspenns", "Sophomore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeCourses");

            migrationBuilder.DropTable(
                name: "FavoriteBooks");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
