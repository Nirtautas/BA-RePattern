using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class Badge2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badge_Category_CategoryId",
                table: "Badge");

            migrationBuilder.DropIndex(
                name: "IX_Badge_CategoryId",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Badge");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Badge",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Badge_CategoryId",
                table: "Badge",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badge_Category_CategoryId",
                table: "Badge",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
