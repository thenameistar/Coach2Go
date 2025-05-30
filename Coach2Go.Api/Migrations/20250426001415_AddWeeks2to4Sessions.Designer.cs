﻿// <auto-generated />
using Coach2Go.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Coach2Go.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250426001415_AddWeeks2to4Sessions")]
    partial class AddWeeks2to4Sessions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Coach2Go.Api.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WorkoutSessionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "40 secs",
                            ImagePath = "images/jumping-jack.png",
                            Name = "Jumping Jacks",
                            WorkoutSessionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Details = "12 reps",
                            ImagePath = "images/squat.png",
                            Name = "Squats",
                            WorkoutSessionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Details = "10 reps",
                            ImagePath = "images/pushup.png",
                            Name = "Push Ups",
                            WorkoutSessionId = 1
                        },
                        new
                        {
                            Id = 4,
                            Details = "15 reps",
                            ImagePath = "images/glutebridges.png",
                            Name = "Glute Bridges",
                            WorkoutSessionId = 1
                        },
                        new
                        {
                            Id = 5,
                            Details = "1 min",
                            ImagePath = "images/plank.png",
                            Name = "Plank",
                            WorkoutSessionId = 1
                        });
                });

            modelBuilder.Entity("Coach2Go.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Coach2Go.Api.Models.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Intensity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 20,
                            Experience = "Beginner",
                            Goal = "Lose Weight",
                            Intensity = "Low",
                            Type = "Bodyweight"
                        });
                });

            modelBuilder.Entity("Coach2Go.Api.Models.WorkoutSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Week")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutPlanId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("WorkoutSessions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 0,
                            ImagePath = "images/workout1.jpg",
                            Title = "Full Body",
                            Week = 1,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 2,
                            Duration = 0,
                            ImagePath = "images/cardiocore.jpg",
                            Title = "Cardio & Core",
                            Week = 1,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 3,
                            Duration = 0,
                            ImagePath = "images/activerecovery1.jpg",
                            Title = "Active Recovery",
                            Week = 1,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 4,
                            Duration = 0,
                            ImagePath = "images/lowerbody.jpg",
                            Title = "Lower Body",
                            Week = 1,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 5,
                            Duration = 0,
                            ImagePath = "images/hiit.jpg",
                            Title = " HIIT",
                            Week = 1,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 6,
                            Duration = 0,
                            ImagePath = "images/yoga.jpg",
                            Title = "Yoga",
                            Week = 1,
                            WorkoutPlanId = 1
                        });
                });

            modelBuilder.Entity("Coach2Go.Api.Models.Exercise", b =>
                {
                    b.HasOne("Coach2Go.Api.Models.WorkoutSession", "WorkoutSession")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutSession");
                });

            modelBuilder.Entity("Coach2Go.Api.Models.WorkoutPlan", b =>
                {
                    b.HasOne("Coach2Go.Api.Models.User", "User")
                        .WithMany("Plans")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Coach2Go.Api.Models.WorkoutSession", b =>
                {
                    b.HasOne("Coach2Go.Api.Models.WorkoutPlan", "WorkoutPlan")
                        .WithMany("Sessions")
                        .HasForeignKey("WorkoutPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkoutPlan");
                });

            modelBuilder.Entity("Coach2Go.Api.Models.User", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("Coach2Go.Api.Models.WorkoutPlan", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Coach2Go.Api.Models.WorkoutSession", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
