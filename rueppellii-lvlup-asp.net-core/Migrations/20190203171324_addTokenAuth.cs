using Microsoft.EntityFrameworkCore.Migrations;

namespace rueppellii_lvlup_asp.net_core.Migrations
{
    public partial class addTokenAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenAuth",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenAuth",
                table: "Users");
        }
    }
}
