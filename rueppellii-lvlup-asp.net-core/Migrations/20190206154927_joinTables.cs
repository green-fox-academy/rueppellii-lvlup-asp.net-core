using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rueppellii_lvlup_asp.net_core.Migrations
{
    public partial class joinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Archetypes_ArchetypesId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Users_UsersId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Badges_BadgesId",
                table: "Levels");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Pitches_PitchesId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Levels_LevelsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LevelsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PitchesId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Levels_BadgesId",
                table: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Badges_ArchetypesId",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_Badges_UsersId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "LevelsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PitchesId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BadgeName",
                table: "Pitches");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Pitches");

            migrationBuilder.DropColumn(
                name: "BadgesId",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "ArchetypesId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Badges");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Levels",
                newName: "BadgeLevel");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "PitchId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Pitches",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Pitches",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BadgesId",
                table: "Pitches",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Pitches",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "LevelId",
                table: "Pitches",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Levels",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "BadgeId",
                table: "Levels",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Badges",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Archetypes",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "ArchetypeLevels",
                columns: table => new
                {
                    ArchetypeId = table.Column<long>(nullable: false),
                    LevelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchetypeLevels", x => new { x.ArchetypeId, x.LevelId });
                    table.ForeignKey(
                        name: "FK_ArchetypeLevels_Archetypes_ArchetypeId",
                        column: x => x.ArchetypeId,
                        principalTable: "Archetypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchetypeLevels_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLevels",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LevelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLevels", x => new { x.UserId, x.LevelId });
                    table.ForeignKey(
                        name: "FK_UserLevels_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLevels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PitchId",
                table: "Reviews",
                column: "PitchId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitches_LevelId",
                table: "Pitches",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_BadgeId",
                table: "Levels",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypeLevels_LevelId",
                table: "ArchetypeLevels",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLevels_LevelId",
                table: "UserLevels",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Badges_BadgeId",
                table: "Levels",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pitches_Levels_LevelId",
                table: "Pitches",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Pitches_PitchId",
                table: "Reviews",
                column: "PitchId",
                principalTable: "Pitches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Badges_BadgeId",
                table: "Levels");

            migrationBuilder.DropForeignKey(
                name: "FK_Pitches_Levels_LevelId",
                table: "Pitches");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Pitches_PitchId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ArchetypeLevels");

            migrationBuilder.DropTable(
                name: "UserLevels");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PitchId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Pitches_LevelId",
                table: "Pitches");

            migrationBuilder.DropIndex(
                name: "IX_Levels_BadgeId",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "PitchId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Pitches");

            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Levels");

            migrationBuilder.RenameColumn(
                name: "BadgeLevel",
                table: "Levels",
                newName: "Level");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "LevelsId",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PitchesId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Pitches",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Timestamp",
                table: "Pitches",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "BadgesId",
                table: "Pitches",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Pitches",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "BadgeName",
                table: "Pitches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Pitches",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Levels",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "BadgesId",
                table: "Levels",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Badges",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ArchetypesId",
                table: "Badges",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Badges",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Archetypes",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelsId",
                table: "Users",
                column: "LevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PitchesId",
                table: "Reviews",
                column: "PitchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_BadgesId",
                table: "Levels",
                column: "BadgesId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_ArchetypesId",
                table: "Badges",
                column: "ArchetypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_UsersId",
                table: "Badges",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Archetypes_ArchetypesId",
                table: "Badges",
                column: "ArchetypesId",
                principalTable: "Archetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Users_UsersId",
                table: "Badges",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Badges_BadgesId",
                table: "Levels",
                column: "BadgesId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Pitches_PitchesId",
                table: "Reviews",
                column: "PitchesId",
                principalTable: "Pitches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Levels_LevelsId",
                table: "Users",
                column: "LevelsId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
