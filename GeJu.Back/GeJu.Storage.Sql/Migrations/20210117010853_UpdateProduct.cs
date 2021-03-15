using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeJu.Sql.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    FechaModificado = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Existencia = table.Column<bool>(nullable: false),
                    CostoPromedio = table.Column<int>(nullable: false),
                    Vencimiento = table.Column<bool>(nullable: false),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    CodigoBarra = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<int>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
                    MarcaId1 = table.Column<Guid>(nullable: true),
                    TamanhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId1",
                        column: x => x.MarcaId1,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tamaños",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    FechaModificado = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamaños", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTamaños",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(nullable: false),
                    TamañoId = table.Column<Guid>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTamaños", x => new { x.ProductoId, x.TamañoId });
                    table.ForeignKey(
                        name: "FK_ProductoTamaños_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoTamaños_Tamaños_TamañoId",
                        column: x => x.TamañoId,
                        principalTable: "Tamaños",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId1",
                table: "Productos",
                column: "MarcaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTamaños_TamañoId",
                table: "ProductoTamaños",
                column: "TamañoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoTamaños");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Tamaños");
        }
    }
}
