﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial2_Ap1_Kevin_Duran.DAL;

#nullable disable

namespace Parcial2_Ap1_Kevin_Duran.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230320230019_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("Parcial2_Ap1_Kevin_Duran.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 590.0,
                            Descripcion = "Caja de Almendras",
                            Existencia = 12,
                            Precio = 650.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 590.0,
                            Descripcion = "Caja de Arandanos",
                            Existencia = 12,
                            Precio = 650.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 590.0,
                            Descripcion = "Caja de Ciruelas",
                            Existencia = 12,
                            Precio = 650.0
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 590.0,
                            Descripcion = "Caja de Pasas",
                            Existencia = 12,
                            Precio = 650.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 590.0,
                            Descripcion = "Caja de Mani",
                            Existencia = 12,
                            Precio = 650.0
                        },
                        new
                        {
                            ProductoId = 6,
                            Costo = 590.0,
                            Descripcion = "Caja de Pistachos",
                            Existencia = 12,
                            Precio = 650.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
