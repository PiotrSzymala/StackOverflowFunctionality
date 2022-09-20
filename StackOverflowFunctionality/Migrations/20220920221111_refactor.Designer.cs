﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackOverflowFunctionality.Entities;

#nullable disable

namespace StackOverflowFunctionality.Migrations
{
    [DbContext(typeof(StackOverflowFunctionalityContext))]
    [Migration("20220920221111_refactor")]
    partial class refactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("AnswerAuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Reply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnswerAuthorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionCommentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuestionCommentId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Header")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("QuestionAuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuestionAuthorId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.QuestionTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("TagId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionTag");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnswerRatingId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("QuestionRatingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerRatingId")
                        .IsUnique();

                    b.HasIndex("QuestionRatingId")
                        .IsUnique();

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Value = "SQL"
                        },
                        new
                        {
                            Id = 3,
                            Value = "Python"
                        },
                        new
                        {
                            Id = 4,
                            Value = "Java"
                        });
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Answer", b =>
                {
                    b.HasOne("StackOverflowFunctionality.Entities.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("AnswerAuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StackOverflowFunctionality.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Comment", b =>
                {
                    b.HasOne("StackOverflowFunctionality.Entities.Question", "Question")
                        .WithMany("Comments")
                        .HasForeignKey("QuestionCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Question", b =>
                {
                    b.HasOne("StackOverflowFunctionality.Entities.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.QuestionTag", b =>
                {
                    b.HasOne("StackOverflowFunctionality.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflowFunctionality.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Rating", b =>
                {
                    b.HasOne("StackOverflowFunctionality.Entities.Answer", "Answer")
                        .WithOne("Rating")
                        .HasForeignKey("StackOverflowFunctionality.Entities.Rating", "AnswerRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflowFunctionality.Entities.Question", "Question")
                        .WithOne("Rating")
                        .HasForeignKey("StackOverflowFunctionality.Entities.Rating", "QuestionRatingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Answer", b =>
                {
                    b.Navigation("Rating");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("StackOverflowFunctionality.Entities.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
