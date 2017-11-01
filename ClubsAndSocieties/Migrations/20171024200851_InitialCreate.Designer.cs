﻿// <auto-generated />
using ClubsAndSocieties.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ClubsAndSocieties.Migrations
{
    [DbContext(typeof(ClubAndSocContext))]
    [Migration("20171024200851_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClubsAndSocieties.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.ClubEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubID");

                    b.Property<int?>("ClubsAndSocietyId");

                    b.Property<int>("EventID");

                    b.HasKey("Id");

                    b.HasIndex("ClubsAndSocietyId");

                    b.HasIndex("EventID");

                    b.ToTable("ClubEvent");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.ClubsAndSociety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminID");

                    b.Property<int?>("AdministratorId");

                    b.Property<string>("Chairperson")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Secretary")
                        .IsRequired();

                    b.Property<string>("Treasurer")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("ClubsAndSocieties");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubID");

                    b.Property<int?>("ClubsAndSocietyId");

                    b.Property<int>("StudentID");

                    b.HasKey("Id");

                    b.HasIndex("ClubsAndSocietyId");

                    b.HasIndex("StudentID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminID");

                    b.Property<int?>("AdministratorId");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Message");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date");

                    b.Property<int>("EventID");

                    b.Property<string>("PostMessage");

                    b.Property<int>("StudentID");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("EventID");

                    b.HasIndex("StudentID");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Course")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.ClubEvent", b =>
                {
                    b.HasOne("ClubsAndSocieties.Models.ClubsAndSociety", "ClubsAndSociety")
                        .WithMany("ClubEvents")
                        .HasForeignKey("ClubsAndSocietyId");

                    b.HasOne("ClubsAndSocieties.Models.Event", "Event")
                        .WithMany("ClubEvents")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.ClubsAndSociety", b =>
                {
                    b.HasOne("ClubsAndSocieties.Models.Administrator", "Administrator")
                        .WithMany("ClubsAndSocieties")
                        .HasForeignKey("AdministratorId");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Member", b =>
                {
                    b.HasOne("ClubsAndSocieties.Models.ClubsAndSociety", "ClubsAndSociety")
                        .WithMany("Members")
                        .HasForeignKey("ClubsAndSocietyId");

                    b.HasOne("ClubsAndSocieties.Models.Student", "Student")
                        .WithMany("Members")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Notification", b =>
                {
                    b.HasOne("ClubsAndSocieties.Models.Administrator", "Administrator")
                        .WithMany("Notifications")
                        .HasForeignKey("AdministratorId");
                });

            modelBuilder.Entity("ClubsAndSocieties.Models.Post", b =>
                {
                    b.HasOne("ClubsAndSocieties.Models.Event", "Event")
                        .WithMany("Posts")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClubsAndSocieties.Models.Student", "Student")
                        .WithMany("Posts")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
