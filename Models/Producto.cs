using System.ComponentModel.DataAnnotations;

namespace Parcial2_Ap1_Kevin_Duran.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double  Costo { get; set; }
        public int Existencia { get; set; }

        public Producto()
        {
            this.Descripcion = string.Empty;
            this.Precio = 0;
            this.Costo = 0;
            this.Existencia = 0;
        }

    }
}
