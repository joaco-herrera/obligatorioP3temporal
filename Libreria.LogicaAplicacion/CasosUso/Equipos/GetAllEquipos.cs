using Libreria.LogicaAplicacion.Dtos.Equipos;
using Libreria.LogicaNegocio.InterfacesLogicaAplicacion;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAplicacion.CasosUso.Equipos
{
    public class GetAllEquipos : ICUGetAll<EquipoDtoListado>
    {
        private IRepositorioEquipo _repo;

        public GetAllEquipos(IRepositorioEquipo repo)
        {
            _repo = repo;
        }

        public IEnumerable<EquipoDtoListado> Execute()
        {
            var equipos = _repo.GetAll();
            var resultado = new List<EquipoDtoListado>();

            foreach (var equipo in equipos)
            {
                resultado.Add(new EquipoDtoListado(
                    equipo.Id,
                    equipo.Nombre.Value
                ));
            }

            return resultado;
        }
    }
}