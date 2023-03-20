using Parcial2_Ap1_Kevin_Duran.DAL;
using Parcial2_Ap1_Kevin_Duran.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial2_Ap1_Kevin_Duran.BLL
{
    public class EntradaBLL
    {
        public Contexto _contexto { get; set; }
        public EntradaBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public bool Existe(int EntradaId)
        {
            return _contexto.Entradas.Any(o=>o.EntradaId == EntradaId);
        }

        public bool Guardar(Entrada entrada)
        {
            try
            {
                if(Existe(entrada.EntradaId))
                {
                    return Modificar(entrada);
                }
                else
                {
                    return Insertar(entrada);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Insertar(Entrada entrada)
        {
            try
            {
                bool cambios;

                if (entrada != null)
                {
                    //reducimos el stock
                    foreach (var item in entrada.Detalles)
                    {
                        var producto = _contexto.Productos.Find(item.ProductoId);
                        if(producto != null)
                        {
                            producto.Existencia -= item.Cantidad;
                            _contexto.Update(producto);
                            _contexto.SaveChanges();
                            _contexto.Entry(producto).State = EntityState.Detached;
                        }
                    }

                    //calculamos la cantidad utilizada
                    var cantidades = from detalle in entrada.Detalles select detalle.Cantidad;
                    entrada.Cantidad = cantidades.Sum();

                    //Insertamos La entrada
                   
                    _contexto.Add(entrada);
                    _contexto.Entry(entrada).State = EntityState.Detached;
                    cambios= _contexto.SaveChanges() > 0;
                    return cambios;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Modificar(Entrada entrada)
        {
            try
            {
                bool cambios;
                var anterior = _contexto.Entradas.Where(o=>o.EntradaId==entrada.EntradaId).Include(o=>o.Detalles).AsNoTracking().SingleOrDefault();

                //Eliminamos los detalles anteriores del inventario
                if(anterior != null)
                {
                    foreach (var item in anterior.Detalles)
                    {
                        var producto = _contexto.Productos.Find(item.ProductoId);
                        if (producto != null)
                        {
                            producto.Existencia += item.Cantidad;
                            _contexto.Update(producto);
                            _contexto.SaveChanges();
                            _contexto.Entry(producto).State = EntityState.Detached;
                        }
                    }
                }

                //eliminamos de la base de datos
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM EntradasDetalles where EntradaId = {entrada.EntradaId}");


                //agregamos los nuevos Detalles 
                foreach (var item in entrada.Detalles)
                {
                    _contexto.Entry(item).State = EntityState.Added; 

                    var producto = _contexto.Productos.Find(item.ProductoId);
                    if (producto != null)
                    {
                        producto.Existencia -= item.Cantidad;
                        _contexto.Update(producto);
                        _contexto.SaveChanges();
                        _contexto.Entry(producto).State = EntityState.Detached;
                    }
                }

                //Modificamos la entrada
                _contexto.Update(entrada);
                cambios = _contexto.SaveChanges() > 0;
                _contexto.Entry(entrada).State = EntityState.Detached;
                return cambios;
            }
            catch
            {
                throw;
            }
        }

        public bool Eliminar(Entrada entrada)
        {
            try
            {
                if(entrada != null)
                {
                    bool cambios;

                    //Eliminamos los detalles  del inventario
                    if (entrada != null)
                    {
                        foreach (var item in entrada.Detalles)
                        {
                            var producto = _contexto.Productos.Find(item.ProductoId);
                            if (producto != null)
                            {
                                producto.Existencia += item.Cantidad;
                                _contexto.Update(producto);
                                _contexto.SaveChanges();
                                _contexto.Entry(producto).State = EntityState.Detached;
                            }
                        }
                    }


                    _contexto.Entradas.Remove(entrada);
                    cambios = _contexto.SaveChanges() > 0;
                    _contexto.Entry(entrada).State = EntityState.Detached;
                    _contexto.Database.ExecuteSqlRaw($"DELETE FROM Entradas where EntradaId = {entrada.EntradaId}");
                    return cambios;
                }
                else
                { 
                    return false;
                }
        
            }
            catch
            {
                throw;
            }
        }

        public Entrada? Buscar(int EntradaId)
        {
            return _contexto.Entradas.Where(o=>o.EntradaId == EntradaId).AsNoTracking().FirstOrDefault();
        }

        public List<Entrada> getList()
        {
            return _contexto.Entradas.AsNoTracking().ToList();
        }

    }
}
