using Microsoft.EntityFrameworkCore;
using Parcial2_Ap1_Kevin_Duran.Models;

namespace Parcial2_Ap1_Kevin_Duran.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }
        
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductoId = 1,
                    Descripcion = "Caja de Almendras",
                    Costo = 590,
                    Precio = 650,
                    Existencia = 12
                },
                 new Producto
                {
                    ProductoId = 2,
                    Descripcion = "Caja de Arandanos",
                    Costo = 590,
                    Precio = 650,
                    Existencia = 12
                },
                new Producto
                {
                    ProductoId = 3,
                    Descripcion = "Caja de Ciruelas",
                    Costo = 590,
                    Precio = 650,
                    Existencia = 12
                },
                new Producto
                {
                    ProductoId = 4,
                    Descripcion = "Caja de Pasas",
                    Costo = 590,
                    Precio = 650,
                    Existencia = 12
                },
                new Producto
                {
                    ProductoId = 5,
                    Descripcion = "Caja de Mani",
                    Costo = 590,
                    Precio = 650,
                    Existencia = 12
                },
                new Producto
                {
                    ProductoId = 6,
                    Descripcion = "Caja de Pistachos",
                    Costo = 590,
                    Precio = 650,
                    Existencia = 12
                }
                ) ;
        }

    }



}
