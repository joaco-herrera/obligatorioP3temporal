using Libreria.LogicaAplicacion.Dtos.Usuarios;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaAplicacion.Mapper;


namespace Libreria.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetByIdUsuarios : ICUGetById<UsuarioDtoListado>
    {
        private IRepositorioUsuario _repo;

        public GetByIdUsuarios(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioDtoListado Execute(int id)
        {
            return UsuarioMapper.ToDto(_repo.GetById(id));
        }
    }
}
