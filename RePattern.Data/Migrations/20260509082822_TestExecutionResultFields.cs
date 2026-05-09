using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestExecutionResultFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectQuestionsCount",
                table: "TestExecution",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ScorePercentage",
                table: "TestExecution",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuestionsCount",
                table: "TestExecution",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectQuestionsCount",
                table: "TestExecution");

            migrationBuilder.DropColumn(
                name: "ScorePercentage",
                table: "TestExecution");

            migrationBuilder.DropColumn(
                name: "TotalQuestionsCount",
                table: "TestExecution");
        }
    }
}
