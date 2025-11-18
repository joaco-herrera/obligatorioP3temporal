using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Mapper;



namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetAllUsuarios : ICUGetAll<UsuarioDtoListado>
    {
        private IRepositorioUsuario _repo;

        public GetAllUsuarios(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public IEnumerable<UsuarioDtoListado> Execute()
        {
            return UsuarioMapper.ToListDto(_repo.GetAll());
    }
}

}
