using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Data.Migrations
{
    public partial class blogCommentFKblog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComment_Blog_FKBlog",
                table: "BlogComment");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCommentId",
                table: "BlogComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FKBlog",
                table: "BlogComment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComment_Blog_FKBlog",
                table: "BlogComment",
                column: "FKBlog",
                principalTable: "Blog",
                principalColumn: "blog_id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_BlogComment_Blog_FKBlog",
                table: "BlogComment");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCommentId",
                table: "BlogComment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FKBlog",
                table: "BlogComment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComment_Blog_FKBlog",
                table: "BlogComment",
                column: "FKBlog",
                principalTable: "Blog",
                principalColumn: "blog_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComment_BlogComment_ParentCommentId",
                table: "BlogComment",
                column: "ParentCommentId",
                principalTable: "BlogComment",
                principalColumn: "comment_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
