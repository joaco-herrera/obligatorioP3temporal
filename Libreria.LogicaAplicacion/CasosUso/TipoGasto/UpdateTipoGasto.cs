using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;

public class UpdateTipoGasto : ICUUpdate<TipoGastoDtoAlta>
{
    private readonly IRepositorioTipoGasto _repo;
    private readonly IRepositorioAuditoria _auditoria;

    public UpdateTipoGasto(IRepositorioTipoGasto repo, IRepositorioAuditoria auditoria)
    {
        _repo = repo;
        _auditoria = auditoria;
    }

    public void Execute(int id, TipoGastoDtoAlta dto)
    {
        var tipoGasto = TipoGastoMapper.FromDto(dto);
        _repo.Update(id, tipoGasto);

        var log = new Auditoria("UPDATE", "TipoGasto", id, "Admin", $"Modificó tipo de gasto: {tipoGasto.Nombre.Value}");
        _auditoria.Registrar(log);
    }
}