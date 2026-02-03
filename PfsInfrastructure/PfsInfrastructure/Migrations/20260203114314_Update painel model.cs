using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PfsInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatepainelmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DbConnectionString",
                schema: "Management",
                table: "Painels");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "Management",
                table: "Painels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DbConnectionString",
                schema: "Management",
                table: "Painels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                schema: "Management",
                table: "Painels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
