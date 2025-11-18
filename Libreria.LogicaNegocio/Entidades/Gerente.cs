using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Gerente : Usuario

    {
        protected Gerente() { }
        public Gerente(VoNombre nombre, VoApellido apellido, VoEmail email, VoPassword password, int equipoId)
            : base(nombre, apellido, email, password, "Gerente", equipoId) { }
    }

}
