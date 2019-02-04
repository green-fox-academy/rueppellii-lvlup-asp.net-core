using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rueppellii_lvlup_asp.net_core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Version = table.Column<string>(maxLength: 15, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Tag = table.Column<string>(maxLength: 50, nullable: false),
                    ArchetypesId = table.Column<int>(nullable: true),
                    UsersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badges_Archetypes_ArchetypesId",
                        column: x => x.ArchetypesId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    BadgesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Pic = table.Column<string>(nullable: true),
                    LevelsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Levels_LevelsId",
                        column: x => x.LevelsId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pitches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Username = table.Column<string>(nullable: true),
                    BadgeName = table.Column<string>(nullable: true),
                    OldLevel = table.Column<int>(nullable: false),
                    PitchedLevel = table.Column<int>(nullable: false),
                    PitchMessage = table.Column<string>(maxLength: 200, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    BadgesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pitches_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pitches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    PitchStatus = table.Column<bool>(nullable: false),
                    PitchesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Pitches_PitchesId",
                        column: x => x.PitchesId,
                        principalTable: "Pitches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badges_ArchetypesId",
                table: "Badges",
                column: "ArchetypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_UsersId",
                table: "Badges",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_BadgesId",
                table: "Levels",
                column: "BadgesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitches_BadgesId",
                table: "Pitches",
                column: "BadgesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitches_UserId",
                table: "Pitches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PitchesId",
                table: "Reviews",
                column: "PitchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelsId",
                table: "Users",
                column: "LevelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Users_UsersId",
                table: "Badges",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Archetypes_ArchetypesId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Users_UsersId",
                table: "Badges");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Pitches");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Badges");
        }
    }
}
