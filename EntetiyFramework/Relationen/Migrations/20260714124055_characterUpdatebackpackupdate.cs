using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relationen.Migrations
{
    /// <inheritdoc />
    public partial class characterUpdatebackpackupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks");

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks",
                column: "CharacterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks");

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks",
                column: "CharacterId");
        }
    }
}
