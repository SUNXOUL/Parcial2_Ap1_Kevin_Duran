﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial2_Ap1_Kevin_Duran.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, 590.0, "Caja de Almendras", 12, 650.0 },
                    { 2, 590.0, "Caja de Arandanos", 12, 650.0 },
                    { 3, 590.0, "Caja de Ciruelas", 12, 650.0 },
                    { 4, 590.0, "Caja de Pasas", 12, 650.0 },
                    { 5, 590.0, "Caja de Mani", 12, 650.0 },
                    { 6, 590.0, "Caja de Pistachos", 12, 650.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
