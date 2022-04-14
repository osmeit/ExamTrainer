using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamTrainer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Examid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_Examid",
                        column: x => x.Examid,
                        principalTable: "Exams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Anwsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    isCorrect = table.Column<bool>(type: "INTEGER", nullable: false),
                    Questionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anwsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Anwsers_Questions_Questionid",
                        column: x => x.Questionid,
                        principalTable: "Questions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anwsers_Questionid",
                table: "Anwsers",
                column: "Questionid");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Examid",
                table: "Questions",
                column: "Examid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anwsers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
