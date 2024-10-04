using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Service
{
    public class TrabajosService
    {
        private readonly Context _context;
        public TrabajosService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Trabajos.AnyAsync(w => w.TrabajoId== id);
        }

        public async Task<bool> Modificar(Trabajos trabajos)
        {
            _context.Trabajos.Update(trabajos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insertar(Trabajos trabajos)
        {
            _context.Trabajos.Add(trabajos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Trabajos trabajos)
        {
            if (!await Existe(trabajos.TrabajoId))
                return await Insertar(trabajos);
            return await Modificar(trabajos);
        }

        public async Task<bool> Eliminar(int id)
        {
            var trabajos = await _context.Trabajos.FirstOrDefaultAsync(w => w.TrabajoId == id);
            if (trabajos != null)
            {
                _context.Trabajos.Remove(trabajos);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
        {
            return await _context.Trabajos
                .Include(w => w.Tecnicos).Include( w => w.Clientes).Include(w => w.Prioridades)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

      
        public async Task<Trabajos> Buscar(int id)
        {
            return await _context.Trabajos
                .Include(w => w.Tecnicos).Include(w => w.Clientes)
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.TrabajoId== id);
        }

        public async Task<bool> ExisteDescripcion(string descripcion)
        {
            return await _context.Trabajos.AnyAsync(t => t.Descripcion == descripcion);
        }

    }
}

