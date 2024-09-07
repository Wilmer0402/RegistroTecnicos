using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RegistroTecnicos.Service
{
    public class TiposTecnicosService
    {
        private readonly Context _context;
        public TiposTecnicosService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.TiposTecnicos.AnyAsync(w => w.Id == id);
        }

        public async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
        {
            _context.TiposTecnicos.Update(tiposTecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
        {
            _context.TiposTecnicos.Add(tiposTecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TiposTecnicos tiposTecnicos)
        {
            if (!await Existe(tiposTecnicos.Id))
                return await Insertar(tiposTecnicos);
            return await Modificar(tiposTecnicos);
        }

        public async Task<bool> Eliminar(int id)
        {
            var tiposTecnicos = await _context.TiposTecnicos.FirstOrDefaultAsync(w => w.Id == id);
            if (tiposTecnicos != null)
            {
                _context.TiposTecnicos.Remove(tiposTecnicos);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
        {
            return await _context.TiposTecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<TiposTecnicos> Buscar(int id)
        {
            return await _context.TiposTecnicos.AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<bool> ExisteDescripcion(string descripcion)
        {
            var descripccionNormalizado = descripcion.Trim().ToLower();
            return await _context.TiposTecnicos
                .AnyAsync(t => t.Descripcion.Trim().ToLower() == descripccionNormalizado);
        }



    }
}

