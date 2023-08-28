using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_ComplejosDeportivos_ComplejoDeportivoId",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "ComplejoDeportivoId",
                table: "Eventos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_ComplejosDeportivos_ComplejoDeportivoId",
                table: "Eventos",
                column: "ComplejoDeportivoId",
                principalTable: "ComplejosDeportivos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_ComplejosDeportivos_ComplejoDeportivoId",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "ComplejoDeportivoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_ComplejosDeportivos_ComplejoDeportivoId",
                table: "Eventos",
                column: "ComplejoDeportivoId",
                principalTable: "ComplejosDeportivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
