using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToCreatedAtOnTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Peso = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uuid", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    PrioridadTarea = table.Column<int>(type: "integer", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 8, 5, 10, 9, 57, 624, DateTimeKind.Local).AddTicks(6720))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12502"), null, "Actividades personales", 50 },
                    { new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded125d7"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo", "categoriaId" },
                values: new object[,]
                {
                    { new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12510"), null, new DateTime(2023, 8, 5, 8, 9, 57, 624, DateTimeKind.Utc).AddTicks(6030), 1, "Pago de servicios publicos", new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded125d7") },
                    { new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12511"), null, new DateTime(2023, 8, 5, 8, 9, 57, 624, DateTimeKind.Utc).AddTicks(6030), 0, "Terminar de ver pelicula en Netflix", new Guid("60ecf22d-fcf7-4d2f-8dd7-ea12ded12502") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_categoriaId",
                table: "Tarea",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
