using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Service
{
	public class PrioridadesService
	{
		private readonly Context _context;
		
		public PrioridadesService(Context context)
		{
			_context = context;
		}

		public async Task<bool> Existe (int id)
		{
			return await _context.Prioridades.AnyAsync(w => w.PrioridadId == id);
		}

		public async Task<bool> Modificar (Prioridades prioridades)
		{
			_context.Prioridades.Update(prioridades);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Insertar(Prioridades prioridades)
		{
			_context.Prioridades.Add(prioridades);
			return await _context.SaveChangesAsync() > 0;
		}

		 public async Task<bool> Guardar(Prioridades prioridades)
		{
			if (!await Existe(prioridades.PrioridadId)) 
				return await Insertar(prioridades);
			return await Modificar(prioridades);
		}

		public async Task<bool> Eliminar(int id)
		{
			var prioridades = await _context.Prioridades.FirstOrDefaultAsync(w => w.PrioridadId == id);
			if (prioridades != null)
			{
				_context.Prioridades.Remove(prioridades);
				return await _context.SaveChangesAsync() > 0;
			}

			return false;
		}

		public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
		{
			return await _context.Prioridades
				.AsNoTracking()
				.Where(criterio)
				.ToListAsync();
		}

		public async Task<Prioridades> Buscar (int id)
		{
			return await _context.Prioridades.AsNoTracking()
				.FirstOrDefaultAsync(w => w.PrioridadId == id);
		}
			
		public async Task<bool> ExistePrioridad(string prioridad)
		{
			var prioridadNormalizado = prioridad.Trim().ToLower();
			return await _context.Prioridades
				.AnyAsync (w => w.Descripcion.Trim().ToLower()== prioridadNormalizado);
		}

	}
}
