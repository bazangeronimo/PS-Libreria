using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Template.AccessData.Migrations
{
    public partial class MyFirstDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    softDelete = table.Column<bool>(type: "bit", nullable: false),
                    salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Usuario_Id);
                });

            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    Caracteristica_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    softDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.Caracteristica_Id);
                    table.ForeignKey(
                        name: "FK_features_users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "users",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "follows",
                columns: table => new
                {
                    FollowKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_Fk = table.Column<int>(type: "int", nullable: false),
                    seguido_Fk = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    softDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follows", x => x.FollowKey);
                    table.ForeignKey(
                        name: "FK_follows_users_seguido_Fk",
                        column: x => x.seguido_Fk,
                        principalTable: "users",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_follows_users_usuario_Fk",
                        column: x => x.usuario_Fk,
                        principalTable: "users",
                        principalColumn: "Usuario_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_features_UsuarioId",
                table: "features",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_follows_seguido_Fk",
                table: "follows",
                column: "seguido_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_follows_usuario_Fk",
                table: "follows",
                column: "usuario_Fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropTable(
                name: "follows");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
