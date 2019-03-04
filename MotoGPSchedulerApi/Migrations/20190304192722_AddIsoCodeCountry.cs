using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoGPSchedulerApi.Migrations
{
    public partial class AddIsoCodeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsoCode",
                table: "Country",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "Country");
        }
    }
}
