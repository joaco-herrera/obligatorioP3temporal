using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesDominio;
using Libreria.LogicaNegocio.Vo;

public class Usuario : IEntity, IValidable
{
    public int Id { get; set; }
    public VoNombre Nombre { get; set; }
    public VoApellido Apellido { get; set; }
    public VoEmail Email { get; set; }
    public VoPassword Password { get; set; }
    public int EquipoId { get; set; }
    public Equipo? Equipo { get; set; }

    public string Rol { get; set; }

    public Usuario() { }

    protected Usuario(VoNombre nombre, VoApellido apellido, VoEmail email, VoPassword password, string rol, int equipoId)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
        Rol = rol;
        EquipoId = equipoId;
        Validable();
    }

    public void Validable()
    {
        if (Nombre == null) throw new Exception("El nombre es obligatorio");
        if (Apellido == null) throw new Exception("El apellido es obligatorio");
        if (Email == null) throw new Exception("El email es obligatorio");
        if (Password == null) throw new Exception("La contraseña es obligatoria");
        if (string.IsNullOrEmpty(Rol)) throw new Exception("El rol es obligatorio");

        var rolesPermitidos = new[] { "Admin", "Empleado", "Gerente" };
        if (!rolesPermitidos.Contains(Rol))
            throw new Exception($"Rol no válido. Debe ser: {string.Join(", ", rolesPermitidos)}");
    }

    public bool Equals(Usuario? other)
    {
        if (other == null) return false;
        return Id.Equals(other.Id);
    }

    public void Update(Usuario obj)
    {
        Nombre = new VoNombre(obj.Nombre.Value);
        Apellido = new VoApellido(obj.Apellido.Value);
        Email = new VoEmail(obj.Email.Value);
        Rol = obj.Rol;
        EquipoId = obj.EquipoId;
        Validable();
    }

    public static Usuario CrearPorRol(VoNombre nombre, VoApellido apellido, VoEmail email, VoPassword password, string rol, int equipoId)
    {
        return rol switch
        {
            "Admin" => new Admin(nombre, apellido, email, password, equipoId),
            "Gerente" => new Gerente(nombre, apellido, email, password, equipoId),
            "Empleado" => new Empleado(nombre, apellido, email, password, equipoId),
            _ => throw new Exception($"Rol '{rol}' no válido")
        };
    }
}