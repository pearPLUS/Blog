using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Data.Migrations
{
    public partial class BlogCommentChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment");

      

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment",
                column: "ParentCommentId",
                principalTable: "BlogComment",
                principalColumn: "comment_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment");

      

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment",
                column: "ParentCommentId",
                principalTable: "BlogComment",
                principalColumn: "comment_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
