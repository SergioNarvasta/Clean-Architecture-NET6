using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Usuarios_UsuarioId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Eventos_EventoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Usuarios_UsuarioId",
                table: "Eventos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Usuarios_UsuarioId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_UsuarioId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Usuarios_UsuarioId",
                table: "Roles",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Eventos_EventoId",
                table: "Usuarios",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
