using Libreria.LogicaNegocio.Vo;

public class Admin : Usuario

{
    protected Admin() { }
    public Admin(VoNombre nombre, VoApellido apellido, VoEmail email, VoPassword password, int equipoId)
        : base(nombre, apellido, email, password, "Admin", equipoId) { }
}
