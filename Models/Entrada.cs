using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2_Ap1_Kevin_Duran.Models
{
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Concepto { get; set; }
        public int ProductoId { get; set; }
        public int ProducidoTotal { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("EntradaId")]
        public List<EntradaDetalle> Detalles = new List<EntradaDetalle>();
    }

    public class EntradaDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
