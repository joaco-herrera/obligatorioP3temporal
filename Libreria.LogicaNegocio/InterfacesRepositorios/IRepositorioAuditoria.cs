using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAuditoria
{
    void Registrar(Auditoria auditoria);
}
}