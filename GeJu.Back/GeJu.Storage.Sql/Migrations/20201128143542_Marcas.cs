using Microsoft.EntityFrameworkCore.Migrations;

namespace GeJu.Sql.Migrations
{
    public partial class Marcas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Usuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificado",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    FechaModificado = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FechaModificado",
                table: "Roles");
        }
    }
}
