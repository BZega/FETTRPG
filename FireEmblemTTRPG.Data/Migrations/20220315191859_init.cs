using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireEmblemTTRPG.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_HP = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Str = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Mag = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Skl = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Spd = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Lck = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Def = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Res = table.Column<int>(type: "int", nullable: false),
                    StatGrowth_Mov = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_HPGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_StrGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_MagGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_SklGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_SpdGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_LckGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_DefGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_ResGrowthRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MaxLevel = table.Column<int>(type: "int", nullable: false),
                    BaseStat_HP = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Str = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Mag = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Skl = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Spd = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Lck = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Def = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Res = table.Column<int>(type: "int", nullable: false),
                    BaseStat_Mov = table.Column<int>(type: "int", nullable: false),
                    MaxStat_HP = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Str = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Mag = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Skl = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Spd = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Lck = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Def = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Res = table.Column<int>(type: "int", nullable: false),
                    MaxStat_Mov = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_HPGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_StrGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_MagGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_SklGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_SpdGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_LckGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_DefGrowthRate = table.Column<int>(type: "int", nullable: false),
                    GrowthRate_ResGrowthRate = table.Column<int>(type: "int", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Might = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Hit = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Crit = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Range = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Extra = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterClass",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterClass", x => new { x.CharacterId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_CharacterClass_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterWeapon",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterWeapon", x => new { x.CharacterId, x.WeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterClass_ClassId",
                table: "CharacterClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterWeapon_WeaponId",
                table: "CharacterWeapon",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterClass");

            migrationBuilder.DropTable(
                name: "CharacterWeapon");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
