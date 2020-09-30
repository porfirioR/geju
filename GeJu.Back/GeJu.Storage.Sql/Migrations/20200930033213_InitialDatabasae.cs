using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeJu.Storage.Sql.Migrations
{
    public partial class InitialDatabasae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    FechaNaciento = table.Column<DateTime>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    Deuda = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
