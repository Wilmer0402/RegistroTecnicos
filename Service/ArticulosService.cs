
using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Service
{
    public class ArticulosService
    {
        private readonly Context _context;

        public ArticulosService(Context context)
        {
            _context = context;
        }

        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            return await _context.Articulos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Articulos> Buscar(int id)
        {
            return await _context.Articulos.AsNoTracking().
                   FirstOrDefaultAsync(w => w.ArticulosId == id);
        }
    }
}

