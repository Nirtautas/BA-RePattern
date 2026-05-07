using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShortText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortText",
                table: "Answer");

            migrationBuilder.AddColumn<string>(
                name: "ShortText",
                table: "TestQuestion",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortText",
                table: "TestQuestion");

            migrationBuilder.AddColumn<string>(
                name: "ShortText",
                table: "Answer",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
