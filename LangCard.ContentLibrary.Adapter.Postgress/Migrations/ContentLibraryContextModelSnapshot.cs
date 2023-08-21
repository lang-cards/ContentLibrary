﻿// <auto-generated />
using System;
using LangCard.ContentLibrary.Adapter.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LangCard.ContentLibrary.Adapter.Postgress.Migrations
{
    [DbContext(typeof(ContentLibraryContext))]
    partial class ContentLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LangCard.ContentLibrary.Adapter.Postgress.Courses.CourseDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TranslateLanguageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name", "LanguageId", "TranslateLanguageId")
                        .IsUnique();

                    b.ToTable("courses", (string)null);
                });

            modelBuilder.Entity("LangCard.ContentLibrary.Adapter.Postgress.Topics.TopicDal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("topics", (string)null);
                });

            modelBuilder.Entity("LangCard.ContentLibrary.Adapter.Postgress.Topics.TopicDal", b =>
                {
                    b.HasOne("LangCard.ContentLibrary.Adapter.Postgress.Courses.CourseDal", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LangCard.ContentLibrary.Adapter.Postgress.Courses.CourseDal", b =>
                {
                    b.Navigation("Topics");
                });
#pragma warning restore 612, 618
        }
    }
}