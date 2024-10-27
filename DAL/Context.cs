using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
        public DbSet<Clientes> Clientes{ get; set; }

        public DbSet<Trabajos> Trabajos{ get; set; }

        public DbSet<Prioridades> Prioridades { get; set; }

        public DbSet<Articulos> Articulos { get; set; }

        public DbSet<TrabajosDetalles> TrabajosDetalles { get; set; }

        public DbSet<Cotizaciones> Cotizaciones { get; set; }

        public DbSet<CotizacionesDetalle> CotizacionesDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
            {
                new Articulos(){ArticulosId=1, Descripcion="RJ45", Costo= 150, Precio= 200, Existencia= 200},
                new Articulos(){ArticulosId=2, Descripcion="MiniJack", Costo= 50, Precio= 65, Existencia= 100},
                new Articulos(){ArticulosId=3, Descripcion="Cable USB", Costo= 250,Precio= 300, Existencia= 125},


            });
        }
    }
}
