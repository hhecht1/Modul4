using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiloPizza.Migrations
{
    /// <inheritdoc />
    public partial class Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Customer",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customer",
                newName: "Adress");
        }
    }
}
