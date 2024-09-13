using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Service
{
    public class ClientesService
    {
        private readonly Context _context;
        public ClientesService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            return await _context.Clientes.AnyAsync(w => w.ClienteId == id);
        }

        public async Task<bool> Modificar(Clientes clientes)
        {
            _context.Clientes.Update(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insertar(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Clientes clientes)
        {
            if (!await Existe(clientes.ClienteId))
                return await Insertar(clientes);
            return await Modificar(clientes);
        }

        public async Task<bool> Eliminar(int id)
        {
            var clientes = await _context.Clientes.FirstOrDefaultAsync(w => w.ClienteId == id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Clientes?> BuscarPorNombre(string nombre)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Nombres == nombre);
        }

        public async Task<Clientes?> Buscar(int id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.ClienteId == id);
        }

        public async Task<bool> ExistePorNombre(string nombre)
        {
            return await _context.Clientes.AnyAsync(t => t.Nombres == nombre);
        }
    }
}


