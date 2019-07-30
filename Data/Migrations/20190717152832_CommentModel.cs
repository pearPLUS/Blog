using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyBlog.Data.Migrations
{
    public partial class CommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogComment",
                columns: table => new
                {
                    comment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment_content = table.Column<string>(nullable: true),
                    comment_date = table.Column<DateTime>(nullable: false),
                    comment_like_count = table.Column<int>(nullable: false),
                    FKParentComment = table.Column<int>(nullable: true),
                    ParentCommentId = table.Column<int>(nullable: true),
                    FKApplicationUser = table.Column<string>(nullable: false),
                    FKBlog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComment", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_BlogComment_AspNetUsers_FKApplicationUser",
                        column: x => x.FKApplicationUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogComment_Blog_FKBlog",
                        column: x => x.FKBlog,
                        principalTable: "Blog",
                        principalColumn: "blog_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BlogComment_BlogComment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "BlogComment",
                        principalColumn: "comment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_FKApplicationUser",
                table: "BlogComment",
                column: "FKApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_FKBlog",
                table: "BlogComment",
                column: "FKBlog");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_ParentCommentId",
                table: "BlogComment",
                column: "ParentCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComment");
        }
    }
}
