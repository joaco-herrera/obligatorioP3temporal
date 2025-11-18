using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.Infraestuctura.AccesoDatos.EF;
using Libreria.LogicaAplicacion.CasosUso.Pagos;
using Libreria.LogicaAplicacion.Dtos.Pagos;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Libreria.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Cargar datos iniciales de prueba a la base de datos
            builder.Services.AddScoped<SeedData>();

            // Inyecto repositorios
            builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();

            // Inyecto casos de uso
            builder.Services.AddScoped<ICUGetById<PagoDtoDetalle>, GetPagoById>();

            // Inyecto el contexto
            builder.Services.AddDbContext<LibreriaContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("Libreria"))
            );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
                    seeder.Run();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}