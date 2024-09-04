using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace RegistroTecnicos.Service
{
    public class TecnicoService
    {
        private readonly Context _context;
        public TecnicoService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Tecnicos.AnyAsync(w => w.TecnicoId == id);
        }

        public async Task<bool> Modificar(Tecnicos tecnico)
        {
            _context.Tecnicos.Update(tecnico);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insertar(Tecnicos tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico.TecnicoId))
                return await Insertar(tecnico);
            return await Modificar(tecnico);
        }

        public async Task<bool> Eliminar(int id)
        {
            var tecnico = await _context.Tecnicos.FirstOrDefaultAsync(w => w.TecnicoId == id);
            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _context.Tecnicos.
                AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Tecnicos?> BuscarNombres(string nombre)
        {
            return await _context.Tecnicos.AsNoTracking()
                .FirstOrDefaultAsync(w => w.NombresTecnico == nombre);
        }

        public async Task<Tecnicos> Buscar(int id)
        {
            return await _context.Tecnicos.AsNoTracking()
                .FirstOrDefaultAsync(w => w.TecnicoId == id);
        }

        public async Task<bool> ValidarTecnico(string nombre)
        {
            return await _context.Tecnicos.AnyAsync(t => t.NombresTecnico == nombre);
        }

        // Agregado el nuevo método
        public async Task<bool> ExistePorNombre(string nombre)
        {
            return await _context.Tecnicos.AnyAsync(t => t.NombresTecnico == nombre);
        }
    }
}

