using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePattern.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestExecutionUserIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestExecution_AspNetUsers_UserId",
                table: "TestExecution");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TestExecution",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_TestExecution_AspNetUsers_UserId",
                table: "TestExecution",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestExecution_AspNetUsers_UserId",
                table: "TestExecution");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TestExecution",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestExecution_AspNetUsers_UserId",
                table: "TestExecution",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
