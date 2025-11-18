using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Mapper;


namespace Libreria.LogicaAplicacion.CasosUso.TipoGasto
{
    public class GetByIdTipoGasto : ICUGetById<TipoGastoDtoListado>
    {
        private IRepositorioTipoGasto _repo;

        public GetByIdTipoGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public TipoGastoDtoListado Execute(int id)
        {
            return TipoGastoMapper.ToDto(_repo.GetById(id));
        }
    }
}
