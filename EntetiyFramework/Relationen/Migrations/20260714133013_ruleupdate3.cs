using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relationen.Migrations
{
    /// <inheritdoc />
    public partial class ruleupdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFactions_Characters_CharactersId",
                table: "CharacterFactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFactions_Faction_FactionsId",
                table: "CharacterFactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterFactions",
                table: "CharacterFactions");

            migrationBuilder.RenameTable(
                name: "CharacterFactions",
                newName: "Zwischentabelle");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterFactions_FactionsId",
                table: "Zwischentabelle",
                newName: "IX_Zwischentabelle_FactionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zwischentabelle",
                table: "Zwischentabelle",
                columns: new[] { "CharactersId", "FactionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Zwischentabelle_Characters_CharactersId",
                table: "Zwischentabelle",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zwischentabelle_Faction_FactionsId",
                table: "Zwischentabelle",
                column: "FactionsId",
                principalTable: "Faction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwischentabelle_Characters_CharactersId",
                table: "Zwischentabelle");

            migrationBuilder.DropForeignKey(
                name: "FK_Zwischentabelle_Faction_FactionsId",
                table: "Zwischentabelle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zwischentabelle",
                table: "Zwischentabelle");

            migrationBuilder.RenameTable(
                name: "Zwischentabelle",
                newName: "CharacterFactions");

            migrationBuilder.RenameIndex(
                name: "IX_Zwischentabelle_FactionsId",
                table: "CharacterFactions",
                newName: "IX_CharacterFactions_FactionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterFactions",
                table: "CharacterFactions",
                columns: new[] { "CharactersId", "FactionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFactions_Characters_CharactersId",
                table: "CharacterFactions",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFactions_Faction_FactionsId",
                table: "CharacterFactions",
                column: "FactionsId",
                principalTable: "Faction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
