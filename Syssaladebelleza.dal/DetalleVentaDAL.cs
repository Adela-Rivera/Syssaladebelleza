using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Syssaladebelleza.DAL;
using Syssaladebelleza.EN;

namespace Syssaladebelleza.DAL
{
    public class DetalleVentaDAL
    {
        public static async Task<int> CrearAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                bdContexto.Add(pDetalleVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                var detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.Id == pDetalleVenta.Id);
                detalleventa.Id = pDetalleVenta.Id;
                detalleventa.IdVenta = pDetalleVenta.IdVenta;
                detalleventa.Precio = pDetalleVenta.Precio;
                detalleventa.Suma = pDetalleVenta.Suma;

                bdContexto.Update(detalleventa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                var detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.Id == pDetalleVenta.Id);
                bdContexto.DetalleVenta.Remove(detalleventa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<DetalleVenta> ObtenerPorIdAsync(DetalleVenta pDetalleVenta)
        {
            var detalleventa = new DetalleVenta();
            using (var bdContexto = new BdContext())
            {
                detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.Id == pDetalleVenta.Id);
            }
            return detalleventa;
        }

        public static async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            var detalleventas = new List<DetalleVenta>();
            using (var bdContexto = new BdContext())
            {
                detalleventas = await bdContexto.DetalleVenta.ToListAsync();
            }
            return detalleventas;
        }

        internal static IQueryable<DetalleVenta> QuerySelect(IQueryable<DetalleVenta> pQuery, DetalleVenta pDetalleVenta)
        {
            if (pDetalleVenta.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pDetalleVenta.Id);

            if (pDetalleVenta.IdVenta > 0)
                pQuery = pQuery.Where(s => s.IdVenta == pDetalleVenta.IdVenta);

            if (pDetalleVenta.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pDetalleVenta.Precio);

            if (pDetalleVenta.Suma > 0)
                pQuery = pQuery.Where(s => s.Suma == pDetalleVenta.Suma);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pDetalleVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pDetalleVenta.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            var detalleventas = new List<DetalleVenta>();
            using (var bdContexto = new BdContext())
            {
                var select = bdContexto.DetalleVenta.AsQueryable();
                select = QuerySelect(select, pDetalleVenta);
                detalleventas = await select.ToListAsync();
            }
            return detalleventas;
        }
    }
}
