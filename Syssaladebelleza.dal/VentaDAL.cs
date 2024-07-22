using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Syssaladebelleza.DAL;
using Syssaladebelleza.EN;


namespace Syssaladebelleza.DAL
{
    public class VentaDAL
    {
        public static async Task<int> CrearAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                bdContexto.Add(pVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                var venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.Id == pVenta.Id);
                if (venta != null)
                {
                    venta.Id = pVenta.Id;
                    venta.IdUsuario = pVenta.IdUsuario;
                    venta.VentasExentas = pVenta.VentasExentas;
                    venta.Descuento = pVenta.Descuento;
                    venta.Iva = pVenta.Iva;
                    venta.Fecha = pVenta.Fecha;
                    venta.Total = pVenta.Total;
                    venta.TotalPagar = pVenta.TotalPagar;
                    venta.Codigo = pVenta.Codigo;
                    venta.Nombre = pVenta.Nombre;
                    venta.Dirrecion = pVenta.Dirrecion;
                    bdContexto.Update(venta);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BdContext())
            {
                var venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.Id == pVenta.Id);
                if (venta != null)
                {
                    bdContexto.Venta.Remove(venta);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            Venta venta = null;
            using (var bdContexto = new BdContext())
            {
                venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.Id == pVenta.Id);
            }
            return venta;
        }

        public static async Task<List<Venta>> ObtenerTodosAsync()
        {
            List<Venta> ventas = null;
            using (var bdContexto = new BdContext())
            {
                ventas = await bdContexto.Venta.ToListAsync();
            }
            return ventas;
        }

        public static IQueryable<Venta> QuerySelect(IQueryable<Venta> pQuery, Venta pVenta)
        {
            if (pVenta.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pVenta.Id);

            if (pVenta.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pVenta.IdUsuario);

            if (pVenta.VentasExentas > 0)
                pQuery = pQuery.Where(s => s.VentasExentas == pVenta.VentasExentas);

            if (pVenta.VentasExentas > 0)
                pQuery = pQuery.Where(s => s.VentasExentas == pVenta.VentasExentas);

            if (pVenta.Descuento > 0)
                pQuery = pQuery.Where(s => s.Descuento == pVenta.Descuento);

            if (pVenta.Iva > 0)
                pQuery = pQuery.Where(s => s.Iva == pVenta.Iva);

            if (pVenta.Total > 0)
                pQuery = pQuery.Where(s => s.Total == pVenta.Total);

            if (pVenta.TotalPagar > 0)
                pQuery = pQuery.Where(s => s.TotalPagar == pVenta.TotalPagar);

            if (pVenta.Codigo > 0)
                pQuery = pQuery.Where(s => s.Codigo == pVenta.Codigo);

            if (!string.IsNullOrWhiteSpace(pVenta.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pVenta.Nombre));

            if (!string.IsNullOrWhiteSpace(pVenta.Dirrecion))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pVenta.Dirrecion));


            if (pVenta.Fecha.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pVenta.Fecha.Year, pVenta.Fecha.Month, pVenta.Fecha.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.Fecha >= fechaInicial && s.Fecha <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pVenta.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            List<Venta>? ventas = null;
            using (var bdContexto = new BdContext())
            {
                var select = bdContexto.Venta.AsQueryable();
                select = QuerySelect(select, pVenta);
                ventas = await select.ToListAsync();
            }
            return ventas;
        }
    }
}

