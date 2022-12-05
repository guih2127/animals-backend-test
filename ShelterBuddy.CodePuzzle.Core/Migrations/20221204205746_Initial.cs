using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterBuddy.CodePuzzle.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Species = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MicrochipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateInShelter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLost = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFound = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgeYears = table.Column<int>(type: "int", nullable: true),
                    AgeMonths = table.Column<int>(type: "int", nullable: true),
                    AgeWeeks = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AgeMonths", "AgeWeeks", "AgeYears", "Color", "CreatedAt", "CreatedBy", "DateFound", "DateInShelter", "DateLost", "DateOfBirth", "IsDeleted", "MicrochipNumber", "Name", "Species" },
                values: new object[] { new Guid("4b7fbe6f-f9b5-479f-a2a0-b0c48e2362db"), 4, 1, 6, "Brown", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Billy", "Dog" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
