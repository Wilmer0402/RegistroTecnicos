using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Service;


namespace RegistroTecnicos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
            builder.Services.AddDbContextFactory<Context>(c => c.UseSqlServer(ConStr));

            //Inyeccion de los  servicios (service)

            builder.Services.AddScoped<TecnicoService>();
            builder.Services.AddScoped<TiposTecnicosService>();
            builder.Services.AddScoped<ClientesService>();
            builder.Services.AddScoped<TrabajosService>();
            builder.Services.AddScoped<PrioridadesService>();
            builder.Services.AddScoped<ArticulosService>();
            builder.Services.AddScoped<CotizacionesService>();
           

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
