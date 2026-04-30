using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class Badges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BadgeGroupId",
                table: "Badge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Badge",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BadgeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsTrackingGroup = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BadgeGroup_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_BadgeGroupId",
                table: "Badge",
                column: "BadgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeGroup_CategoryId_IsTrackingGroup",
                table: "BadgeGroup",
                columns: new[] { "CategoryId", "IsTrackingGroup" },
                unique: true,
                filter: "\"IsTrackingGroup\" = true AND \"CategoryId\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Badge_BadgeGroup_BadgeGroupId",
                table: "Badge",
                column: "BadgeGroupId",
                principalTable: "BadgeGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badge_BadgeGroup_BadgeGroupId",
                table: "Badge");

            migrationBuilder.DropTable(
                name: "BadgeGroup");

            migrationBuilder.DropIndex(
                name: "IX_Badge_BadgeGroupId",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "BadgeGroupId",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Badge");
        }
    }
}
