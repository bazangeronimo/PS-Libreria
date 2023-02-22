using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Template.AccessData.Migrations
{
    public partial class agregaciondeequipodefutbolyubicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EquipoFutbol",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipoFutbol",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "users");
        }
    }
}
