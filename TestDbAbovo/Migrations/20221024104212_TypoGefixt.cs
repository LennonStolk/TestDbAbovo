using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDbAbovo.Migrations
{
    public partial class TypoGefixt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afdelingen_Projects_ProjectId",
                table: "Afdelingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Medewerkers_Projects_ProjectId",
                table: "Medewerkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Klanten_KlantId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Projecten");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_KlantId",
                table: "Projecten",
                newName: "IX_Projecten_KlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projecten",
                table: "Projecten",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Afdelingen_Projecten_ProjectId",
                table: "Afdelingen",
                column: "ProjectId",
                principalTable: "Projecten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerkers_Projecten_ProjectId",
                table: "Medewerkers",
                column: "ProjectId",
                principalTable: "Projecten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projecten_Klanten_KlantId",
                table: "Projecten",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afdelingen_Projecten_ProjectId",
                table: "Afdelingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Medewerkers_Projecten_ProjectId",
                table: "Medewerkers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projecten_Klanten_KlantId",
                table: "Projecten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projecten",
                table: "Projecten");

            migrationBuilder.RenameTable(
                name: "Projecten",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_Projecten_KlantId",
                table: "Projects",
                newName: "IX_Projects_KlantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Afdelingen_Projects_ProjectId",
                table: "Afdelingen",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerkers_Projects_ProjectId",
                table: "Medewerkers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Klanten_KlantId",
                table: "Projects",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
