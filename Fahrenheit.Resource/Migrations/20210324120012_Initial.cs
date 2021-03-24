using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fahrenheit.Resource.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    FireRate = table.Column<int>(type: "int", nullable: false),
                    ReloadSpeed = table.Column<int>(type: "int", nullable: false),
                    MagazineSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    Level_Value = table.Column<int>(type: "int", nullable: true),
                    Level_Experience = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GunСharacter",
                columns: table => new
                {
                    AviableGunsId = table.Column<int>(type: "int", nullable: false),
                    СharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunСharacter", x => new { x.AviableGunsId, x.СharactersId });
                    table.ForeignKey(
                        name: "FK_GunСharacter_Characters_СharactersId",
                        column: x => x.СharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GunСharacter_Guns_AviableGunsId",
                        column: x => x.AviableGunsId,
                        principalTable: "Guns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BaseСharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCharacters_Characters_BaseСharacterId",
                        column: x => x.BaseСharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCharacters_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersGuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BaseGunId = table.Column<int>(type: "int", nullable: true),
                    Level_Value = table.Column<int>(type: "int", nullable: true),
                    Level_Experience = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersGuns_Guns_BaseGunId",
                        column: x => x.BaseGunId,
                        principalTable: "Guns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersGuns_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GunСharacter_СharactersId",
                table: "GunСharacter",
                column: "СharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCharacters_BaseСharacterId",
                table: "UsersCharacters",
                column: "BaseСharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCharacters_OwnerId",
                table: "UsersCharacters",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGuns_BaseGunId",
                table: "UsersGuns",
                column: "BaseGunId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGuns_OwnerId",
                table: "UsersGuns",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GunСharacter");

            migrationBuilder.DropTable(
                name: "UsersCharacters");

            migrationBuilder.DropTable(
                name: "UsersGuns");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Guns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
