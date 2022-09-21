using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackOverflowFunctionality.Migrations
{
    public partial class point_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerRatingId = table.Column<int>(type: "int", nullable: false),
                    QuestionRatingId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Answers_AnswerRatingId",
                        column: x => x.AnswerRatingId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Questions_QuestionRatingId",
                        column: x => x.QuestionRatingId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AnswerRatingId",
                table: "Ratings",
                column: "AnswerRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_QuestionRatingId",
                table: "Ratings",
                column: "QuestionRatingId",
                unique: true);
        }
    }
}
