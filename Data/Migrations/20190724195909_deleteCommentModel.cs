using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Data.Migrations
{
    public partial class deleteCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    comment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FKApplicationUser = table.Column<string>(nullable: false),
                    FKBlog = table.Column<int>(nullable: true),
                    comment_like_count = table.Column<int>(nullable: false),
                    ParentCommentId = table.Column<int>(nullable: true),
                    comment_date = table.Column<DateTime>(nullable: false),
                    comment_content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_FKApplicationUser",
                        column: x => x.FKApplicationUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Blog_FKBlog",
                        column: x => x.FKBlog,
                        principalTable: "Blog",
                        principalColumn: "blog_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comment",
                        principalColumn: "comment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FKApplicationUser",
                table: "Comment",
                column: "FKApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_FKBlog",
                table: "Comment",
                column: "FKBlog");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentCommentId",
                table: "Comment",
                column: "ParentCommentId");
        }
    }
}
