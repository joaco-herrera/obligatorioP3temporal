using Libreria.LogicaAplicacion.Dtos.TipoGasto;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Mapper;

namespace Libreria.LogicaAplicacion.CasosUso.TipoGasto
{
    public class GetAllTiposGasto : ICUGetAll<TipoGastoDtoListado>
    {
        private IRepositorioTipoGasto _repo;

        public GetAllTiposGasto(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public IEnumerable<TipoGastoDtoListado> Execute()
        {
            return TipoGastoMapper.ToListDto(_repo.GetAll());
        }
    }

}