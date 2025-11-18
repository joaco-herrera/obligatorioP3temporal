using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.Infraestuctura.AccesoDatos.EF;
using Libreria.LogicaAplicacion.CasosUso.Equipos;
using Libreria.LogicaAplicacion.CasosUso.MetodosPago;  
using Libreria.LogicaAplicacion.CasosUso.Pagos;  
using Libreria.LogicaAplicacion.CasosUso.TipoGasto;
using Libreria.LogicaAplicacion.CasosUso.Usuarios;
using Libreria.LogicaAplicacion.Dtos.Equipos;
using Libreria.LogicaAplicacion.Dtos.MetodosPago; 
using Libreria.LogicaAplicacion.Dtos.Pagos;  
using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.Vo;
using Microsoft.EntityFrameworkCore;
using Libreria.LogicaAplicacion.CasosUso.Equipos;
using Libreria.LogicaAplicacion.Dtos.Equipos;

namespace Libreria.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LibreriaContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("Libreria"))
            ); 
            builder.Services.AddScoped<ICUGetAll<UsuarioDtoListado>, GetAllUsuarios>();
            builder.Services.AddScoped<ICUAdd<UsuarioDtoAlta>, AddUsuario>();
            builder.Services.AddScoped<ICUGetById<UsuarioDtoListado>, GetByIdUsuarios>();
            builder.Services.AddScoped<ICUUpdate<UsuarioDtoAlta>, UpdateUsuario>();
            builder.Services.AddScoped<ICUDelete<UsuarioDtoAlta>, RemoveUsuario>();
            builder.Services.AddScoped<GetUsuariosPorMontoSuperior>();
            builder.Services.AddScoped<ICUGetAll<TipoGastoDtoListado>, GetAllTiposGasto>();
            builder.Services.AddScoped<ICUAdd<TipoGastoDtoAlta>, AddTipoGasto>();
            builder.Services.AddScoped<ICUGetById<TipoGastoDtoListado>, GetByIdTipoGasto>();
            builder.Services.AddScoped<ICUUpdate<TipoGastoDtoAlta>, UpdateTipoGasto>();
            builder.Services.AddScoped<ICUDelete<TipoGastoDtoAlta>, RemoveTipoGasto>();
            builder.Services.AddScoped<ICUGetAll<EquipoDtoListado>, GetAllEquipos>();
            builder.Services.AddScoped<ICUGetAll<MetodoPagoDtoListado>, GetAllMetodosPago>();
            builder.Services.AddScoped<ICUAdd<PagoDtoAlta>, AddPago>();
            builder.Services.AddScoped<ICUGetAll<PagoDtoListado>, GetAllPagos>();
            builder.Services.AddScoped<ICUGetById<PagoDtoDetalle>, GetPagoById>();
            builder.Services.AddScoped<ICUDelete<PagoDtoAlta>, RemovePago>();
            builder.Services.AddScoped<GetPagosByMesYAnio>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
            builder.Services.AddScoped<IRepositorioMetodoPago, RepositorioMetodoPago>();  
            builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<SeedData>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
                    seeder.Run();
                }
            }
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
            app.Run();
        }
    }
}