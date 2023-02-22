using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Template.AccessData.Migrations
{
    public partial class picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "profilePicture",
                table: "users",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilePicture",
                table: "users");
        }
    }
}
