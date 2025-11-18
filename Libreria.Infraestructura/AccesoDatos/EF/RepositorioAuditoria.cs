using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;

public class RepositorioAuditoria : IRepositorioAuditoria
{
    private LibreriaContext _context;

    public RepositorioAuditoria(LibreriaContext context)
    {
        _context = context;
    }

    public void Registrar(Auditoria auditoria)
    {
        _context.Auditorias.Add(auditoria);
        _context.SaveChanges();
    }
}