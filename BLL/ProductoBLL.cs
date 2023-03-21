using Microsoft.EntityFrameworkCore;
using Parcial2_Ap1_Kevin_Duran.DAL;
using Parcial2_Ap1_Kevin_Duran.Models;

namespace Parcial2_Ap1_Kevin_Duran.BLL
{
    public class ProductoBLL
    {
        public Contexto _contexto { get; set; }
        public ProductoBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }


        public List<Producto> getList()
        {
            return _contexto.Productos.AsNoTracking().ToList();
        }
        public Producto? Buscar(int ProductoId)
        {
            return _contexto.Productos.Find(ProductoId);
        }
        public bool Existe(int ProductoId)
        {
            return _contexto.Productos.Any(o => o.ProductoId == ProductoId);
        }
    }
}
