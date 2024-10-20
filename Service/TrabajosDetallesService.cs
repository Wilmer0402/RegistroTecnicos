using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using Microsoft.EntityFrameworkCore;


namespace RegistroTecnicos.Service
{
    public class TrabajosDetallesService
    {
        private readonly Context _context;

        public TrabajosDetallesService(Context context)
        {
            _context = context;
        }

        public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
        {
            return await _context.Trabajos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}


