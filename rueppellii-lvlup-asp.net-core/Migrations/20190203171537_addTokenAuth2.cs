using Microsoft.EntityFrameworkCore.Migrations;

namespace rueppellii_lvlup_asp.net_core.Migrations
{
    public partial class addTokenAuth2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenAuth",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenAuth",
                table: "Users",
                nullable: true);
        }
    }
}
