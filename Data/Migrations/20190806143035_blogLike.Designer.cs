﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Data;

namespace MyBlog.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190806143035_blogLike")]
    partial class blogLike
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyBlog.Areas.Identity.Data.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MyBlog.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("ArticleCount")
                        .HasColumnName("article_count");

                    b.Property<DateTime>("Birthday")
                        .HasColumnName("user_birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("user_name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnName("user_profile_photo");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnName("user_regisration_time");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("age")
                        .HasColumnName("user_age");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyBlog.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("blog_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogBrief")
                        .IsRequired()
                        .HasColumnName("blog_brief");

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasColumnName("blog_content");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasColumnName("blog_title");

                    b.Property<int>("BrowseCount")
                        .HasColumnName("blog_views");

                    b.Property<int>("CommentCount")
                        .HasColumnName("blog_comment_count");

                    b.Property<string>("FKApplicationUser")
                        .IsRequired();

                    b.Property<int>("FkCatergory");

                    b.Property<int>("LikeCount")
                        .HasColumnName("blog_like_count");

                    b.Property<DateTime>("PostTime")
                        .HasColumnName("blog_date");

                    b.HasKey("Id");

                    b.HasIndex("FKApplicationUser");

                    b.HasIndex("FkCatergory");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("MyBlog.Models.BlogComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("comment_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FKApplicationUser")
                        .IsRequired();

                    b.Property<int?>("FKBlog");

                    b.Property<int>("FKParentComment");

                    b.Property<int>("LikeCount")
                        .HasColumnName("comment_like_count");

                    b.Property<int?>("ParentCommentId");

                    b.Property<string>("ParentCommentName");

                    b.Property<DateTime>("PostTime")
                        .HasColumnName("comment_date");

                    b.Property<string>("content")
                        .HasColumnName("comment_content");

                    b.HasKey("Id");

                    b.HasIndex("FKApplicationUser");

                    b.HasIndex("FKBlog");

                    b.HasIndex("ParentCommentId");

                    b.ToTable("BlogComment");
                });

            modelBuilder.Entity("MyBlog.Models.BlogLabel", b =>
                {
                    b.Property<int>("BlogId");

                    b.Property<int>("LabelId");

                    b.HasKey("BlogId", "LabelId");

                    b.HasIndex("LabelId");

                    b.ToTable("BlogLabel");
                });

            modelBuilder.Entity("MyBlog.Models.BlogLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bloglike_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId")
                        .HasColumnName("blog_id");

                    b.Property<short>("Status")
                        .HasColumnName("like_status");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("BlogLike");
                });

            modelBuilder.Entity("MyBlog.Models.Catergory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("catergory_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("catergory_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("catergory_name")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Catergory");
                });

            modelBuilder.Entity("MyBlog.Models.label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("label_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("label_description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("label_name");

                    b.HasKey("Id");

                    b.ToTable("label");
                });

            modelBuilder.Entity("MyBlog.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("post_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasColumnName("post_content");

                    b.Property<int>("CommentCount")
                        .HasColumnName("post_comment_count");

                    b.Property<int>("LikeCount")
                        .HasColumnName("post_like_count");

                    b.Property<DateTime>("PostTime")
                        .HasColumnName("post_date");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("MyBlog.Models.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TodoItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBlog.Models.Blog", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Blogs")
                        .HasForeignKey("FKApplicationUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Models.Catergory", "Catergory")
                        .WithMany("Blogs")
                        .HasForeignKey("FkCatergory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBlog.Models.BlogComment", b =>
                {
                    b.HasOne("MyBlog.Areas.Identity.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("FKApplicationUser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Models.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("FKBlog");

                    b.HasOne("MyBlog.Models.BlogComment", "ParentComment")
                        .WithMany("ChildComment")
                        .HasForeignKey("ParentCommentId");
                });

            modelBuilder.Entity("MyBlog.Models.BlogLabel", b =>
                {
                    b.HasOne("MyBlog.Models.Blog", "Blog")
                        .WithMany("LabelsBlogs")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Models.label", "Label")
                        .WithMany("BlogLabels")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
