using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroisAPI.Migrations
{
    /// <inheritdoc />
    public partial class migracao3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroiSuperPoder_SuperPoder_SuperPoderesId",
                table: "HeroiSuperPoder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperPoder",
                table: "SuperPoder");

            migrationBuilder.DropColumn(
                name: "SuperPoder",
                table: "Herois");

            migrationBuilder.RenameTable(
                name: "SuperPoder",
                newName: "SuperPoderes");

            migrationBuilder.RenameColumn(
                name: "Aniversario",
                table: "Herois",
                newName: "Nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperPoderes",
                table: "SuperPoderes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroiSuperPoder_SuperPoderes_SuperPoderesId",
                table: "HeroiSuperPoder",
                column: "SuperPoderesId",
                principalTable: "SuperPoderes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetDefault);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroiSuperPoder_SuperPoderes_SuperPoderesId",
                table: "HeroiSuperPoder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperPoderes",
                table: "SuperPoderes");

            migrationBuilder.RenameTable(
                name: "SuperPoderes",
                newName: "SuperPoder");

            migrationBuilder.RenameColumn(
                name: "Nascimento",
                table: "Herois",
                newName: "Aniversario");

            migrationBuilder.AddColumn<string>(
                name: "SuperPoder",
                table: "Herois",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperPoder",
                table: "SuperPoder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroiSuperPoder_SuperPoder_SuperPoderesId",
                table: "HeroiSuperPoder",
                column: "SuperPoderesId",
                principalTable: "SuperPoder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
