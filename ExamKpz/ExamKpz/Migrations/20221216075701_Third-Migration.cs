using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamKpz.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LawCaseId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LawCaseId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LawCaseId",
                table: "Documents",
                column: "LawCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LawCaseId",
                table: "Comments",
                column: "LawCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_LawCases_LawCaseId",
                table: "Comments",
                column: "LawCaseId",
                principalTable: "LawCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_LawCases_LawCaseId",
                table: "Documents",
                column: "LawCaseId",
                principalTable: "LawCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_LawCases_LawCaseId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_LawCases_LawCaseId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_LawCaseId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Comments_LawCaseId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LawCaseId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LawCaseId",
                table: "Comments");
        }
    }
}
