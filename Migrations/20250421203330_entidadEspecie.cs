using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppVete.Migrations
{
    /// <inheritdoc />
    public partial class entidadEspecie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especie",
                table: "Mascotas");

            migrationBuilder.AddColumn<int>(
                name: "EspecieId",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_EspecieId",
                table: "Mascotas",
                column: "EspecieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Especies_EspecieId",
                table: "Mascotas",
                column: "EspecieId",
                principalTable: "Especies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Especies_EspecieId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_EspecieId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "EspecieId",
                table: "Mascotas");

            migrationBuilder.AddColumn<string>(
                name: "Especie",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
