using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson11.Migrations
{
    /// <inheritdoc />
    public partial class AddDateOfBirthToAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Authors",
                type: "date",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Authors");
        }
    }
}
