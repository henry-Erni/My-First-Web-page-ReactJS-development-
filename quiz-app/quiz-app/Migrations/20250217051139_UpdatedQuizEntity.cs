using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_app.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedQuizEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Quizzes",
                newName: "Options");

            migrationBuilder.AddColumn<int>(
                name: "CorrectOption",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectOption",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "Options",
                table: "Quizzes",
                newName: "Answer");
        }
    }
}
