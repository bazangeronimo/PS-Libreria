using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoDeAlquilerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoDeAlquilerId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Edicion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Stock = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadoDeAlquilerId = table.Column<int>(type: "int", nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_EstadoDeAlquilerId",
                        column: x => x.EstadoDeAlquilerId,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoDeAlquilerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoDeAlquilerId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "9782409014932", "Godoc Eric", "2018", "Eni", "https://bit.ly/3Nq8w7m", 10, "SQL 'Los fundamentos del lenguaje' " },
                    { "9786125020024", "Montero Rosa", "2021", "Alfaguara", "https://bit.ly/3Ojwt1j", 10, "La Buena Suerte" },
                    { "9788417289362", "Capel Tuñon Manuel I", "2022", "GARCETA GRUPO EDITORIAL", "https://bit.ly/3ygRfsU", 10, "Programación concurrente y en tiempo real" },
                    { "9788437604947", "Gabriel Garcia Marquez", "2007", "Ediciones Cátedra", "https://bit.ly/3HMVDmm", 10, "Cien Años de Soledad" },
                    { "9788441526372", "Beaulieu Alan", "2009", "ANAYA MULTIMEDIA", "https://bit.ly/3tWVIhy", 10, "Aprende SQL" },
                    { "9788478290598", "Erich Gamma", "2002", "ADDISON WESLEY", "https://bit.ly/3njK38N", 10, "Patrones de Diseño" },
                    { "9789504935575", "Gabriel Rolon", "2013", "Planeta Publishing", "https://bit.ly/3nc2jB1", 10, "Palabras Cruzadas" },
                    { "9789504970934", "Gabriel Rolon", "2021", "Planeta Publishing", "https://bit.ly/3A2pxBu", 10, "El duelo" },
                    { "9789506444808", "King Stephen", "2018", "Plaza & Janes Editores", "https://bit.ly/3zW9ViN", 10, "El Visitante" },
                    { "9789506445386", "King Stephen", "2020", "Plaza & Janes Editores", "https://bit.ly/3xNnyyc", 10, "La Sangre Manda" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ClienteId",
                table: "Alquileres",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_EstadoDeAlquilerId",
                table: "Alquileres",
                column: "EstadoDeAlquilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ISBN",
                table: "Alquileres",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
