using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireEmblemTTRPG.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeaponType2",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponType3",
                table: "Classes",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeaponType2",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "WeaponType3",
                table: "Classes");
        }
    }
}
