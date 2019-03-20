using Microsoft.EntityFrameworkCore.Migrations;

namespace BethanysPieShop.Migrations
{
    public partial class piereview1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PieReview_Pies_PieId",
                table: "PieReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieReview",
                table: "PieReview");

            migrationBuilder.RenameTable(
                name: "PieReview",
                newName: "PieReviews");

            migrationBuilder.RenameIndex(
                name: "IX_PieReview_PieId",
                table: "PieReviews",
                newName: "IX_PieReviews_PieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieReviews",
                table: "PieReviews",
                column: "PieReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_PieReviews_Pies_PieId",
                table: "PieReviews",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PieReviews_Pies_PieId",
                table: "PieReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PieReviews",
                table: "PieReviews");

            migrationBuilder.RenameTable(
                name: "PieReviews",
                newName: "PieReview");

            migrationBuilder.RenameIndex(
                name: "IX_PieReviews_PieId",
                table: "PieReview",
                newName: "IX_PieReview_PieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PieReview",
                table: "PieReview",
                column: "PieReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_PieReview_Pies_PieId",
                table: "PieReview",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
