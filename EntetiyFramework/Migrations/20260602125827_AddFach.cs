using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntetiyFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fach",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fach",
                table: "Students");
        }
    }
}
