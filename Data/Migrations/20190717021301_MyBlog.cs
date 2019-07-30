using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyBlog.Data.Migrations
{
    public partial class MyBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "article_count",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "user_birthday",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_profile_photo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "user_regisration_time",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_age",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catergory",
                columns: table => new
                {
                    catergory_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    catergory_name = table.Column<string>(maxLength: 10, nullable: false),
                    catergory_description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catergory", x => x.catergory_id);
                });

            migrationBuilder.CreateTable(
                name: "label",
                columns: table => new
                {
                    label_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    label_name = table.Column<string>(nullable: false),
                    label_description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_label", x => x.label_id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    blog_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FkCatergory = table.Column<int>(nullable: false),
                    blog_title = table.Column<string>(nullable: false),
                    blog_brief = table.Column<string>(nullable: false),
                    blog_content = table.Column<string>(nullable: false),
                    blog_date = table.Column<DateTime>(nullable: false),
                    blog_like_count = table.Column<int>(nullable: false),
                    blog_comment_count = table.Column<int>(nullable: false),
                    blog_views = table.Column<int>(nullable: false),
                    FKApplicationUser = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.blog_id);
                    table.ForeignKey(
                        name: "FK_Blog_AspNetUsers_FKApplicationUser",
                        column: x => x.FKApplicationUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blog_Catergory_FkCatergory",
                        column: x => x.FkCatergory,
                        principalTable: "Catergory",
                        principalColumn: "catergory_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogLabel",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false),
                    LabelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogLabel", x => new { x.BlogId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_BlogLabel_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "blog_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogLabel_label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "label",
                        principalColumn: "label_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_FKApplicationUser",
                table: "Blog",
                column: "FKApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_FkCatergory",
                table: "Blog",
                column: "FkCatergory");

            migrationBuilder.CreateIndex(
                name: "IX_BlogLabel_LabelId",
                table: "BlogLabel",
                column: "LabelId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "BlogLabel");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "label");

            migrationBuilder.DropTable(
                name: "Catergory");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "article_count",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_profile_photo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_regisration_time",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_age",
                table: "AspNetUsers");
        }
    }
}
