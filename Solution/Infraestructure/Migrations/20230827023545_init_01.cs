using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SedesOlimpicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NroComplejos = table.Column<int>(type: "int", nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedesOlimpicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplejosDeportivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    SedeOlimpicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplejosDeportivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplejosDeportivos_SedesOlimpicas_SedeOlimpicaId",
                        column: x => x.SedeOlimpicaId,
                        principalTable: "SedesOlimpicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Especificos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplejoDeportivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especificos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especificos_ComplejosDeportivos_ComplejoDeportivoId",
                        column: x => x.ComplejoDeportivoId,
                        principalTable: "ComplejosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    NroParticipantes = table.Column<int>(type: "int", nullable: false),
                    NroComisarios = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ComplejoDeportivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_ComplejosDeportivos_ComplejoDeportivoId",
                        column: x => x.ComplejoDeportivoId,
                        principalTable: "ComplejosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polideportivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    InicioAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ComplejoDeportivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polideportivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polideportivos_ComplejosDeportivos_ComplejoDeportivoId",
                        column: x => x.ComplejoDeportivoId,
                        principalTable: "ComplejosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamientos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    ComplejoDeportivoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_ComplejosDeportivos_ComplejoDeportivoId",
                        column: x => x.ComplejoDeportivoId,
                        principalTable: "ComplejosDeportivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuarios_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreasDeportivas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndLocalizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    PolideportivoId = table.Column<int>(type: "int", nullable: true),
                    DeporteEspecificoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasDeportivas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreasDeportivas_Especificos_DeporteEspecificoid",
                        column: x => x.DeporteEspecificoid,
                        principalTable: "Especificos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AreasDeportivas_Polideportivos_PolideportivoId",
                        column: x => x.PolideportivoId,
                        principalTable: "Polideportivos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AreaDeportivaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deportes_AreasDeportivas_AreaDeportivaId",
                        column: x => x.AreaDeportivaId,
                        principalTable: "AreasDeportivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_UsuarioId",
                table: "Accesos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeportivas_DeporteEspecificoid",
                table: "AreasDeportivas",
                column: "DeporteEspecificoid",
                unique: true,
                filter: "[DeporteEspecificoid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AreasDeportivas_PolideportivoId",
                table: "AreasDeportivas",
                column: "PolideportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplejosDeportivos_SedeOlimpicaId",
                table: "ComplejosDeportivos",
                column: "SedeOlimpicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Deportes_AreaDeportivaId",
                table: "Deportes",
                column: "AreaDeportivaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamientos_EventoId",
                table: "Equipamientos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Especificos_ComplejoDeportivoId",
                table: "Especificos",
                column: "ComplejoDeportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ComplejoDeportivoId",
                table: "Eventos",
                column: "ComplejoDeportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Polideportivos_ComplejoDeportivoId",
                table: "Polideportivos",
                column: "ComplejoDeportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ComplejoDeportivoId",
                table: "Usuarios",
                column: "ComplejoDeportivoId",
                unique: true,
                filter: "[ComplejoDeportivoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DropTable(
                name: "Deportes");

            migrationBuilder.DropTable(
                name: "Equipamientos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AreasDeportivas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Especificos");

            migrationBuilder.DropTable(
                name: "Polideportivos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "ComplejosDeportivos");

            migrationBuilder.DropTable(
                name: "SedesOlimpicas");
        }
    }
}
