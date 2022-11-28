using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbAbovo.Migrations
{
    public partial class ForeignKeysNullableGemaakt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medewerkers_Afdelingen_AfdelingId",
                table: "Medewerkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projecten_Klanten_KlantId",
                table: "Projecten");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Projecten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AfdelingId",
                table: "Medewerkers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerkers_Afdelingen_AfdelingId",
                table: "Medewerkers",
                column: "AfdelingId",
                principalTable: "Afdelingen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projecten_Klanten_KlantId",
                table: "Projecten",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medewerkers_Afdelingen_AfdelingId",
                table: "Medewerkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projecten_Klanten_KlantId",
                table: "Projecten");

            migrationBuilder.AlterColumn<int>(
                name: "KlantId",
                table: "Projecten",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AfdelingId",
                table: "Medewerkers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerkers_Afdelingen_AfdelingId",
                table: "Medewerkers",
                column: "AfdelingId",
                principalTable: "Afdelingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projecten_Klanten_KlantId",
                table: "Projecten",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
