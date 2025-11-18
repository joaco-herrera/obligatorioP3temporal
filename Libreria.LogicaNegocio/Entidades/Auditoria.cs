using Libreria.LogicaNegocio.InterfacesDominio;
using System;
namespace Libreria.LogicaNegocio.Entidades
{
    public class Auditoria : IEntity
{
    public int Id { get; set; }
    public string Accion { get; set; }
    public string Tabla { get; set; }
    public int IdObjeto { get; set; }
    public string Usuario { get; set; }
    public DateTime Fecha { get; set; }
    public string Detalles { get; set; }
    public Auditoria(string accion, string tabla, int idObjeto, string usuario, string detalles)
    {
        Accion = accion;
        Tabla = tabla;
        IdObjeto = idObjeto;
        Usuario = usuario;
        Fecha = DateTime.Now;
        Detalles = detalles;
    }
    public bool Equals(Auditoria other) => other != null && Id.Equals(other.Id);
}
}