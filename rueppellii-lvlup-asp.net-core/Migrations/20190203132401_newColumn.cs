using Microsoft.EntityFrameworkCore.Migrations;

namespace rueppellii_lvlup_asp.net_core.Migrations
{
    public partial class newColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testColumn",
                table: "Badges",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testColumn",
                table: "Badges");
        }
    }
}
