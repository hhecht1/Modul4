using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relationen.Migrations
{
    /// <inheritdoc />
    public partial class ruleupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Characters_CharactersId",
                table: "CharacterFaction");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFaction_Faction_FactionsId",
                table: "CharacterFaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterFaction",
                table: "CharacterFaction");

            migrationBuilder.RenameTable(
                name: "CharacterFaction",
                newName: "CharacterFactions");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterFaction_FactionsId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFactions_Characters_CharactersId",
                table: "CharacterFactions");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterFactions_Faction_FactionsId",
                table: "CharacterFactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterFactions",
                table: "CharacterFactions");

            migrationBuilder.RenameTable(
                name: "CharacterFactions",
                newName: "CharacterFaction");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterFactions_FactionsId",
                table: "CharacterFaction",
                newName: "IX_CharacterFaction_FactionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterFaction",
                table: "CharacterFaction",
                columns: new[] { "CharactersId", "FactionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Characters_CharactersId",
                table: "CharacterFaction",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterFaction_Faction_FactionsId",
                table: "CharacterFaction",
                column: "FactionsId",
                principalTable: "Faction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
