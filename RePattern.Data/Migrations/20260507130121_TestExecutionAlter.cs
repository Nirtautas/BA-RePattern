using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestExecutionAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "TestExecution");

            migrationBuilder.RenameColumn(
                name: "StartedAt",
                table: "TestExecution",
                newName: "CompletedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompletedAt",
                table: "TestExecution",
                newName: "StartedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "TestExecution",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
