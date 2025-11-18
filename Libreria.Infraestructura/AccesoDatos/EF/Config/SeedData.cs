using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Vo;
using Libreria.LogicaNegocio.Utilidades;

namespace Libreria.Infraestuctura.AccesoDatos.EF
{
    public class SeedData
    {
        private LibreriaContext _context;

        public SeedData(LibreriaContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.Equipos.Any()) CreateEquipos();
            if (!_context.Usuarios.Any()) CreateUsuarios();
            if (!_context.TiposGasto.Any()) CreateTiposGasto();
            if (!_context.Pagos.Any()) CreatePagos();
        }

        private void CreateEquipos()
        {
            _context.Equipos.Add(
                new Equipo(new VoNombreEquipo("Equipo Desarrollo"))
            );
            _context.Equipos.Add(
                new Equipo(new VoNombreEquipo("Sin Equipo"))
            );
            _context.Equipos.Add(
                new Equipo(new VoNombreEquipo("Gerencia"))
            );
            _context.SaveChanges();
        }

        private void CreateUsuarios()
        {
            _context.Usuarios.Add(
                new Admin(
                    new VoNombre("Carlos"),
                    new VoApellido("Administrador"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Carlos", "Administrador")),
                    new VoPassword("Admin12345"),
                    3
                )
            );

            _context.Usuarios.Add(
                new Admin(
                    new VoNombre("María"),
                    new VoApellido("González"),
                    new VoEmail(GeneradorEmail.GenerarEmail("María", "González")),
                    new VoPassword("Maria12345"),
                    3
                )
            );

            _context.Usuarios.Add(
                new Admin(
                    new VoNombre("Juan"),
                    new VoApellido("Pérez"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Juan", "Pérez")),
                    new VoPassword("Juan12345"),
                    3
                )
            );

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Ana"),
                    new VoApellido("Rodríguez"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Ana", "Rodríguez")),
                    new VoPassword("Ana12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Roberto"),
                    new VoApellido("Martínez"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Roberto", "Martínez")),
                    new VoPassword("Roberto12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Gerente(
                    new VoNombre("Laura"),
                    new VoApellido("Fernández"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Laura", "Fernández")),
                    new VoPassword("Laura12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Pedro"),
                    new VoApellido("López"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Pedro", "López")),
                    new VoPassword("Pedro12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Sofia"),
                    new VoApellido("García"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Sofia", "García")),
                    new VoPassword("Sofia12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Miguel"),
                    new VoApellido("Sánchez"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Miguel", "Sánchez")),
                    new VoPassword("Miguel12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Valentina"),
                    new VoApellido("Torres"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Valentina", "Torres")),
                    new VoPassword("Valentina12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Andrés"),
                    new VoApellido("Ramírez"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Andrés", "Ramírez")),
                    new VoPassword("Andres12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Camila"),
                    new VoApellido("Díaz"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Camila", "Díaz")),
                    new VoPassword("Camila12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Fernando"),
                    new VoApellido("Núñez"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Fernando", "Núñez")),
                    new VoPassword("Fernando12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Gabriela"),
                    new VoApellido("Romero"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Gabriela", "Romero")),
                    new VoPassword("Gabriela12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Javier"),
                    new VoApellido("Castro"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Javier", "Castro")),
                    new VoPassword("Javier12345"),
                    1
                )
            );

            _context.Usuarios.Add(
                new Empleado(
                    new VoNombre("Martina"),
                    new VoApellido("Silva"),
                    new VoEmail(GeneradorEmail.GenerarEmail("Martina", "Silva")),
                    new VoPassword("Martina12345"),
                    1
                )
            );

            _context.SaveChanges();
        }

        private void CreateTiposGasto()
        {
            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Transporte"),
                    new VoDescripcionGasto("Gastos relacionados con movilidad y transporte")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Alimentación"),
                    new VoDescripcionGasto("Gastos en comida y bebidas")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Servicios"),
                    new VoDescripcionGasto("Pagos de servicios básicos como luz, agua, internet")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Salud"),
                    new VoDescripcionGasto("Gastos médicos y farmacéuticos")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Entretenimiento"),
                    new VoDescripcionGasto("Gastos en ocio, recreación y entretenimiento")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Educación"),
                    new VoDescripcionGasto("Gastos en cursos, libros y materiales educativos")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Oficina"),
                    new VoDescripcionGasto("Suministros y equipos de oficina")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Viáticos"),
                    new VoDescripcionGasto("Gastos de viajes y desplazamientos")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Comunicaciones"),
                    new VoDescripcionGasto("Gastos en telefonía, internet y correo")
                )
            );

            _context.TiposGasto.Add(
                new TipoGasto(
                    new VoNombreGasto("Mantenimiento"),
                    new VoDescripcionGasto("Reparación y mantenimiento de equipos")
                )
            );

            _context.SaveChanges();
        }

        private void CreatePagos()
        {
            var todosUsuarios = _context.Usuarios.ToList();
            var tiposGasto = _context.TiposGasto.ToList();

            var empleados = todosUsuarios
                .Where(u => u.Nombre.Value != "Carlos" && u.Nombre.Value != "María" && u.Nombre.Value != "Juan"
                         && u.Nombre.Value != "Ana" && u.Nombre.Value != "Roberto" && u.Nombre.Value != "Laura")
                .ToList();

            foreach (var emp in empleados)

            if (empleados.Count < 10 || tiposGasto.Count < 10)
            {
                return;
            }

            var pedro = empleados[0];
            var sofia = empleados[1];
            var miguel = empleados[2];
            var valentina = empleados[3];
            var andres = empleados[4];
            var camila = empleados[5];
            var fernando = empleados[6];
            var gabriela = empleados[7];
            var javier = empleados[8];

            var transporte = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Transporte");
            var alimentacion = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Alimentación");
            var servicios = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Servicios");
            var salud = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Salud");
            var entretenimiento = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Entretenimiento");
            var educacion = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Educación");
            var oficina = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Oficina");
            var viaticos = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Viáticos");
            var comunicaciones = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Comunicaciones");
            var mantenimiento = tiposGasto.FirstOrDefault(tg => tg.Nombre.Value == "Mantenimiento");

            if (transporte == null || alimentacion == null || servicios == null || salud == null
             || entretenimiento == null || educacion == null || oficina == null || viaticos == null
             || comunicaciones == null || mantenimiento == null)
            {
                Console.WriteLine("DEBUG: Falta algún tipo de gasto. Retornando sin crear pagos.");
                return;
            }

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Nafta para viaje a cliente"),
                    new VoMonto(150.50m),
                    1,
                    transporte.Id,
                    pedro.Id,
                    new DateTime(2025, 10, 5),
                    "REC001"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Almuerzo de equipo"),
                    new VoMonto(85.75m),
                    2,
                    alimentacion.Id,
                    sofia.Id,
                    new DateTime(2025, 10, 10),
                    "REC002"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Medicinas farmacia"),
                    new VoMonto(320.00m),
                    1,
                    salud.Id,
                    miguel.Id,
                    new DateTime(2025, 10, 15),
                    "REC003"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Material educativo curso"),
                    new VoMonto(200.00m),
                    2,
                    educacion.Id,
                    valentina.Id,
                    new DateTime(2025, 10, 12),
                    "REC004"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Hotel viaje de negocios"),
                    new VoMonto(450.00m),
                    2,
                    viaticos.Id,
                    andres.Id,
                    new DateTime(2025, 10, 8),
                    "REC005"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Tarjeta de débito"),
                    new VoMonto(50.00m),
                    1,
                    servicios.Id,
                    camila.Id,
                    new DateTime(2025, 9, 5),
                    "REC006"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Entradas cine"),
                    new VoMonto(120.00m),
                    2,
                    entretenimiento.Id,
                    fernando.Id,
                    new DateTime(2025, 9, 12),
                    "REC007"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Útiles de escritorio"),
                    new VoMonto(75.50m),
                    1,
                    oficina.Id,
                    gabriela.Id,
                    new DateTime(2025, 9, 20),
                    "REC008"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Reparación impresora"),
                    new VoMonto(180.00m),
                    2,
                    mantenimiento.Id,
                    javier.Id,
                    new DateTime(2025, 9, 25),
                    "REC009"
                )
            );

            _context.Pagos.Add(
                new PagoUnico(
                    new VoDescripcionGasto("Plan de telefonía"),
                    new VoMonto(45.00m),
                    2,
                    comunicaciones.Id,
                    pedro.Id,
                    new DateTime(2025, 9, 28),
                    "REC010"
                )
            );

            _context.SaveChanges();

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Netflix suscripción mensual"),
                    new VoMonto(199.99m),
                    2,
                    entretenimiento.Id,
                    sofia.Id,
                    new VoPeriodoPago(new DateTime(2025, 9, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Office 365 licencia"),
                    new VoMonto(99.99m),
                    2,
                    servicios.Id,
                    miguel.Id,
                    new VoPeriodoPago(new DateTime(2025, 8, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Cuota electrodoméstico"),
                    new VoMonto(250.00m),
                    2,
                    oficina.Id,
                    valentina.Id,
                    new VoPeriodoPago(new DateTime(2025, 10, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Gym membresía"),
                    new VoMonto(150.00m),
                    1,
                    entretenimiento.Id,
                    andres.Id,
                    new VoPeriodoPago(new DateTime(2025, 10, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Seguros auto cuota"),
                    new VoMonto(500.00m),
                    2,
                    transporte.Id,
                    camila.Id,
                    new VoPeriodoPago(new DateTime(2025, 7, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Internet casa"),
                    new VoMonto(80.00m),
                    2,
                    comunicaciones.Id,
                    fernando.Id,
                    new VoPeriodoPago(new DateTime(2025, 9, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Alquiler oficina"),
                    new VoMonto(2000.00m),
                    2,
                    oficina.Id,
                    gabriela.Id,
                    new VoPeriodoPago(new DateTime(2025, 10, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Vigilancia mensual"),
                    new VoMonto(300.00m),
                    2,
                    servicios.Id,
                    javier.Id,
                    new VoPeriodoPago(new DateTime(2025, 8, 1), new DateTime(2025, 11, 30))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Capacitación online"),
                    new VoMonto(120.00m),
                    2,
                    educacion.Id,
                    pedro.Id,
                    new VoPeriodoPago(new DateTime(2025, 10, 1), new DateTime(2025, 12, 31))
                )
            );

            _context.Pagos.Add(
                new PagoRecurrente(
                    new VoDescripcionGasto("Mantenimiento servidor"),
                    new VoMonto(400.00m),
                    2,
                    mantenimiento.Id,
                    sofia.Id,
                    new VoPeriodoPago(new DateTime(2025, 9, 15), new DateTime(2025, 12, 31))
                )
            );

            _context.SaveChanges();
        }
    }
}