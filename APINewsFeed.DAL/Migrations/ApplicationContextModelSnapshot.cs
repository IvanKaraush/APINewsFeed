﻿// <auto-generated />
using System;
using APINewsFeed.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APINewsFeed.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("APINewsFeed.DAL.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<Guid>("postId")
                        .HasColumnType("uuid");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.HasIndex(new[] { "postId" }, "postIdIndex");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.FavoritePost", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("postId")
                        .HasColumnType("uuid");

                    b.HasKey("userId", "postId");

                    b.HasIndex("postId");

                    b.HasIndex(new[] { "userId" }, "userIdIndex");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.Post", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.HasIndex(new[] { "created" }, "createdIndex");

                    b.HasIndex(new[] { "title" }, "titleIndex");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex(new[] { "id" }, "idIndex");

                    b.HasIndex(new[] { "name" }, "nameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.Comment", b =>
                {
                    b.HasOne("APINewsFeed.DAL.Models.Post", "post")
                        .WithMany("Comments")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APINewsFeed.DAL.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("user");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.FavoritePost", b =>
                {
                    b.HasOne("APINewsFeed.DAL.Models.Post", "post")
                        .WithMany("favoritePosts")
                        .HasForeignKey("postId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APINewsFeed.DAL.Models.User", "user")
                        .WithMany("favoritePosts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("user");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.Post", b =>
                {
                    b.HasOne("APINewsFeed.DAL.Models.User", "user")
                        .WithMany("posts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("favoritePosts");
                });

            modelBuilder.Entity("APINewsFeed.DAL.Models.User", b =>
                {
                    b.Navigation("favoritePosts");

                    b.Navigation("posts");
                });
#pragma warning restore 612, 618
        }
    }
}
