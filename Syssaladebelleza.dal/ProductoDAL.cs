using Microsoft.EntityFrameworkCore;
using Syssaladebelleza.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Syssaladebelleza.DAL
{


    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                bdContexto.Add(pProducto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContext = new BdContext())
            {
                var producto = await bdContext.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                producto.Id = pProducto.Id;
                producto.IdDetalleVenta = pProducto.IdDetalleVenta;
                producto.Nombre = pProducto.Nombre;
                producto.Descripcion = pProducto.Descripcion;
                producto.PrecioUnitario = pProducto.PrecioUnitario;
                producto.PrecioVenta = pProducto.PrecioVenta;
                producto.Codigo = pProducto.Codigo;
                producto.Imagen = pProducto.Imagen;
                producto.Marca = pProducto.Marca;
                producto.FechaRegistro = pProducto.FechaRegistro;
                producto.FechaVencimiento = pProducto.FechaVencimiento;
                producto.Categoria = pProducto.Categoria;
                producto.DetalleVenta = pProducto.DetalleVenta;
                producto.Top_Aux = pProducto.Top_Aux;
                bdContext.Update(producto);
                result = await bdContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                var producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                bdContexto.Producto.Remove(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var bdContexto = new BdContext())
            {
                producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
            }
            return producto;
        }
        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BdContext())
            {
                productos = await bdContexto.Producto.ToListAsync();
            }
            return productos;
        }
        internal static IQueryable<Producto> QuerySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProducto.Id);

            if (pProducto.IdDetalleVenta > 0)
                pQuery = pQuery.Where(s => s.IdDetalleVenta == pProducto.IdDetalleVenta);

            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProducto.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProducto.Descripcion));

            if (pProducto.PrecioUnitario > 0)
                pQuery = pQuery.Where(s => s.PrecioUnitario == pProducto.PrecioUnitario);

            if (pProducto.PrecioVenta > 0)
                pQuery = pQuery.Where(s => s.PrecioVenta == pProducto.PrecioVenta);

            if (pProducto.Codigo > 0)
                pQuery = pQuery.Where(s => s.Codigo == pProducto.Codigo);

            if (!string.IsNullOrWhiteSpace(pProducto.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pProducto.Imagen));

            if (!string.IsNullOrWhiteSpace(pProducto.Marca))
                pQuery = pQuery.Where(s => s.Marca.Contains(pProducto.Marca));

            if (!string.IsNullOrWhiteSpace(pProducto.Categoria))
                pQuery = pQuery.Where(s => s.Categoria.Contains(pProducto.Categoria));


            {
                
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BdContext())
            {
                var select = bdContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto);
                productos = await select.ToListAsync();
            }
            return productos;
        }

    }
}