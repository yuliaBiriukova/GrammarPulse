﻿// <auto-generated />
using GrammarPulse.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrammarPulse.DAL.Migrations
{
    [DbContext(typeof(GrammarPulseDbContext))]
    partial class GrammarPulseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrammarPulse.BLL.Entities.CompletedTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("CompletedTopics");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EnglishValue")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UkrainianValue")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Levels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "A1",
                            Name = "Beginner"
                        },
                        new
                        {
                            Id = 2,
                            Code = "A2",
                            Name = "Pre-Intermediate"
                        },
                        new
                        {
                            Id = 3,
                            Code = "B1",
                            Name = "Intermediate"
                        },
                        new
                        {
                            Id = 4,
                            Code = "B2",
                            Name = "Upper-Intermediate"
                        },
                        new
                        {
                            Id = 5,
                            Code = "C1",
                            Name = "Advanced"
                        },
                        new
                        {
                            Id = 6,
                            Code = "C2",
                            Name = "Proficient"
                        });
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.VersionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("TopicVersionEntity", b =>
                {
                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.Property<int>("VersionsId")
                        .HasColumnType("int");

                    b.HasKey("TopicsId", "VersionsId");

                    b.HasIndex("VersionsId");

                    b.ToTable("TopicVersions", (string)null);
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.CompletedTopic", b =>
                {
                    b.HasOne("GrammarPulse.BLL.Entities.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrammarPulse.BLL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Exercise", b =>
                {
                    b.HasOne("GrammarPulse.BLL.Entities.Topic", "Topic")
                        .WithMany("Exercises")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Topic", b =>
                {
                    b.HasOne("GrammarPulse.BLL.Entities.Level", "Level")
                        .WithMany("Topics")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("TopicVersionEntity", b =>
                {
                    b.HasOne("GrammarPulse.BLL.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrammarPulse.BLL.Entities.VersionEntity", null)
                        .WithMany()
                        .HasForeignKey("VersionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Level", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("GrammarPulse.BLL.Entities.Topic", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
