using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeJu.Sql.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ContraseñaHash",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ContraseñaSalt",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true,
                filter: "[Correo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Documento",
                table: "Usuarios",
                column: "Documento",
                unique: true,
                filter: "[Documento] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Documento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ContraseñaHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ContraseñaSalt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
