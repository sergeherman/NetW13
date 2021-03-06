﻿// <auto-generated />
using System;
using MeetingPlanner2020.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingPlanner2020.Migrations
{
    [DbContext(typeof(MeetingPlanner2020Context))]
    [Migration("20201207122350_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetingPlanner2020.Models.Meeting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConductingID")
                        .HasColumnType("int");

                    b.Property<int?>("PrayerClosingID")
                        .HasColumnType("int");

                    b.Property<int?>("PrayerOpeningID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOf")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("timeOf")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ConductingID");

                    b.HasIndex("PrayerClosingID");

                    b.HasIndex("PrayerOpeningID");

                    b.ToTable("Meeting");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calling")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MeetingID")
                        .HasColumnType("int");

                    b.Property<string>("SongTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MeetingID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ThemeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Talk", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MeetingID")
                        .HasColumnType("int");

                    b.Property<int?>("SpeakerID")
                        .HasColumnType("int");

                    b.Property<string>("TalkTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MeetingID");

                    b.HasIndex("SpeakerID");

                    b.ToTable("Talk");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Meeting", b =>
                {
                    b.HasOne("MeetingPlanner2020.Models.Person", "Conducting")
                        .WithMany()
                        .HasForeignKey("ConductingID");

                    b.HasOne("MeetingPlanner2020.Models.Person", "PrayerClosing")
                        .WithMany()
                        .HasForeignKey("PrayerClosingID");

                    b.HasOne("MeetingPlanner2020.Models.Person", "PrayerOpening")
                        .WithMany()
                        .HasForeignKey("PrayerOpeningID");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Song", b =>
                {
                    b.HasOne("MeetingPlanner2020.Models.Meeting", null)
                        .WithMany("Songs")
                        .HasForeignKey("MeetingID");
                });

            modelBuilder.Entity("MeetingPlanner2020.Models.Talk", b =>
                {
                    b.HasOne("MeetingPlanner2020.Models.Meeting", null)
                        .WithMany("Talks")
                        .HasForeignKey("MeetingID");

                    b.HasOne("MeetingPlanner2020.Models.Person", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerID");
                });
#pragma warning restore 612, 618
        }
    }
}
