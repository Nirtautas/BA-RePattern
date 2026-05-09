using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestQuestionExplanationField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "TestQuestion",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "TestQuestion");
        }
    }
}
