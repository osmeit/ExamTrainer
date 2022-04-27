using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamTrainer.Migrations
{
    public partial class addkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anwsers_Questions_Questionid",
                table: "Anwsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_Examid",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Examid",
                table: "Questions",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_Examid",
                table: "Questions",
                newName: "IX_Questions_ExamId");

            migrationBuilder.RenameColumn(
                name: "Questionid",
                table: "Anwsers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Anwsers_Questionid",
                table: "Anwsers",
                newName: "IX_Anwsers_QuestionId");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Anwsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anwsers_Questions_QuestionId",
                table: "Anwsers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anwsers_Questions_QuestionId",
                table: "Anwsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "Questions",
                newName: "Examid");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                newName: "IX_Questions_Examid");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Anwsers",
                newName: "Questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Anwsers_QuestionId",
                table: "Anwsers",
                newName: "IX_Anwsers_Questionid");

            migrationBuilder.AlterColumn<int>(
                name: "Examid",
                table: "Questions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Questionid",
                table: "Anwsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Anwsers_Questions_Questionid",
                table: "Anwsers",
                column: "Questionid",
                principalTable: "Questions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_Examid",
                table: "Questions",
                column: "Examid",
                principalTable: "Exams",
                principalColumn: "id");
        }
    }
}
