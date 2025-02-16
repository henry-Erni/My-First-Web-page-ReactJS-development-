using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_app.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuizRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Users_UserId",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Quizzes",
                newName: "QuizRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_UserId",
                table: "Quizzes",
                newName: "IX_Quizzes_QuizRecordId");

            migrationBuilder.CreateTable(
                name: "QuizRecords",
                columns: table => new
                {
                    QuizRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizRecordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizRecords", x => x.QuizRecordId);
                    table.ForeignKey(
                        name: "FK_QuizRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizRecords_UserId",
                table: "QuizRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_QuizRecords_QuizRecordId",
                table: "Quizzes",
                column: "QuizRecordId",
                principalTable: "QuizRecords",
                principalColumn: "QuizRecordId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_QuizRecords_QuizRecordId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "QuizRecords");

            migrationBuilder.RenameColumn(
                name: "QuizRecordId",
                table: "Quizzes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_QuizRecordId",
                table: "Quizzes",
                newName: "IX_Quizzes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Users_UserId",
                table: "Quizzes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
