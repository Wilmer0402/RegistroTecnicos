﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Service
{
    public class CotizacionesService(IDbContextFactory<Context> DbFactory)
    {
        public async Task<bool> Existe(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones.AnyAsync(a => a.CotizacionId == id);
        }

        private async Task<bool> Insertar(Cotizaciones cotizaciones)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            await AfectarArticulo(cotizaciones.CotizacionesDetalle.ToArray(), true);
            contexto.Cotizaciones.Add(cotizaciones);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task AfectarArticulo(CotizacionesDetalle[] detalle, bool resta = true)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            foreach (var item in detalle)
            {
                var Articulo = await contexto.Articulos.SingleAsync(p => p.ArticulosId == item.ArticulosId);
                if (resta)
                    Articulo.Existencia -= item.Cantidad;
                else
                    Articulo.Existencia += item.Cantidad;
            }

            await contexto.SaveChangesAsync();
        }

        private async Task<bool> Modificar(Cotizaciones cotizaciones)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            var cotizacionOriginal = await contexto.Cotizaciones
                .Include(t => t.CotizacionesDetalle)
                .FirstOrDefaultAsync(t => t.CotizacionId == cotizaciones.CotizacionId);

            if (cotizacionOriginal == null)
                return false;

            await AfectarArticulo(cotizacionOriginal.CotizacionesDetalle.ToArray(), false);

            foreach (var detalleOriginal in cotizacionOriginal.CotizacionesDetalle)
            {
                if (!cotizaciones.CotizacionesDetalle.Any(d => d.DetalleId == detalleOriginal.DetalleId))
                {
                    contexto.CotizacionesDetalle.Remove(detalleOriginal);
                }
            }

            await AfectarArticulo(cotizaciones.CotizacionesDetalle.ToArray(), true);

            contexto.Entry(cotizacionOriginal).CurrentValues.SetValues(cotizaciones);

            foreach (var detalle in cotizaciones.CotizacionesDetalle)
            {
                var detalleExistente = cotizacionOriginal.CotizacionesDetalle
                    .FirstOrDefault(d => d.DetalleId == detalle.DetalleId);

                if (detalleExistente != null)
                {
                    contexto.Entry(detalleExistente).CurrentValues.SetValues(detalle);
                }
                else
                {
                    cotizacionOriginal.CotizacionesDetalle.Add(detalle);
                }
            }

            return await contexto.SaveChangesAsync() > 0;
        }



        public async Task<bool> Guardar(Cotizaciones cotizaciones)
        {
            if (!await Existe(cotizaciones.CotizacionId))
                return await Insertar(cotizaciones);
            else
                return await Modificar(cotizaciones);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var cotizacion = await contexto.Cotizaciones
                .Include(t => t.CotizacionesDetalle)
                .ThenInclude(td => td.Articulos)
                .FirstOrDefaultAsync(t => t.CotizacionId == id);

            if (cotizacion == null)
                return false;

            await AfectarArticulo(cotizacion.CotizacionesDetalle.ToArray(), resta: false);

            contexto.CotizacionesDetalle.RemoveRange(cotizacion.CotizacionesDetalle);
            contexto.Cotizaciones.Remove(cotizacion);

            var cantidad = await contexto.SaveChangesAsync();
            return cantidad > 0;
        }

        public async Task<Cotizaciones> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
                .Include(t => t.Clientes)
                .Include(t => t.CotizacionesDetalle)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.CotizacionId == id);
        }

        public async Task<Cotizaciones> BuscarConDetalles(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
                .Include(t => t.Clientes)
                .Include(t => t.CotizacionesDetalle)
                .ThenInclude(td => td.Articulos)
                .FirstOrDefaultAsync(p => p.CotizacionId == id);
        }

        public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var cotizaciones = await contexto.Cotizaciones
                .Include(t => t.Clientes)
                .Include(t => t.CotizacionesDetalle)
                .ThenInclude(td => td.Articulos)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();

            foreach (var cotizacion in cotizaciones)
            {
                cotizacion.Monto = cotizacion.CotizacionesDetalle
                    .Sum(detalle => detalle.Cantidad * detalle.Articulos.Precio);
            }

            return cotizaciones;
        }

    }
}
