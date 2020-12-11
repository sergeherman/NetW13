using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingPlanner2020.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageURL = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Calling = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateOf = table.Column<DateTime>(nullable: false),
                    timeOf = table.Column<DateTime>(nullable: false),
                    ConductingId = table.Column<int>(nullable: false),
                    PrayerOpeningId = table.Column<int>(nullable: true),
                    PrayerClosingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_ConductingId",
                        column: x => x.ConductingId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_PrayerClosingId",
                        column: x => x.PrayerClosingId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_PrayerOpeningId",
                        column: x => x.PrayerOpeningId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongTitle = table.Column<string>(nullable: true),
                    MeetingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Song_Meeting_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meeting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position = table.Column<int>(nullable: false),
                    SpeakerID = table.Column<int>(nullable: true),
                    TalkTitle = table.Column<string>(nullable: true),
                    MeetingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Talk_Meeting_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meeting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talk_Person_SpeakerID",
                        column: x => x.SpeakerID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ConductingId",
                table: "Meeting",
                column: "ConductingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_PrayerClosingId",
                table: "Meeting",
                column: "PrayerClosingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_PrayerOpeningId",
                table: "Meeting",
                column: "PrayerOpeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_MeetingID",
                table: "Song",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_MeetingID",
                table: "Talk",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Talk_SpeakerID",
                table: "Talk",
                column: "SpeakerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Talk");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
