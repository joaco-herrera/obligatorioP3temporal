using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private LibreriaContext _context;

        public RepositorioUsuario(LibreriaContext context)
        {
            _context = context;
        }

        public bool ExisteEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email.Value == email);
        }

        public string GenerarEmailUnico(string nombre, string apellido)
        {
            string emailBase = GeneradorEmail.GenerarEmail(nombre, apellido);

            if (!ExisteEmail(emailBase))
            {
                return emailBase;
            }

            string emailSinDominio = emailBase.Replace("@laempresa.com", "");
            string emailConNumero;

            do
            {
                string numeroAleatorio = GeneradorEmail.GenerarNumeroAleatorio();
                emailConNumero = $"{emailSinDominio}{numeroAleatorio}@laempresa.com";
            } while (ExisteEmail(emailConNumero));

            return emailConNumero;
        }

        public void Add(Usuario obj)
        {
            _context.Usuarios.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios
                .Include(u => u.Equipo)
                .OrderBy(x => x.Nombre.Value)
                .ToList();
        }

        public Usuario GetById(int id)
        {
            Usuario unUsuario = _context.Usuarios
                .Include(u => u.Equipo)
                .FirstOrDefault(usuario => usuario.Id == id);
            if (unUsuario == null)
            {
                throw new UsuarioException("No se encontró el usuario con id: " + id);
            }
            return unUsuario;
        }

        public void Update(int id, Usuario obj)
        {
            var usuarioExistente = _context.Usuarios
                .Include(u => u.Equipo)
                .FirstOrDefault(u => u.Id == id);
            if (usuarioExistente == null)
            {
                throw new UsuarioException("No se encontró el usuario");
            }
            bool emailExiste = false;
            foreach (var usuario in _context.Usuarios.AsNoTracking())
            {
                if (usuario.Email.Value == obj.Email.Value && usuario.Id != id)
                {
                    emailExiste = true;
                    break;
                }
            }
            if (emailExiste)
            {
                throw new MailEnUsoException("Ya existe otro usuario con este email.");
            }
            usuarioExistente.Nombre = obj.Nombre;
            usuarioExistente.Apellido = obj.Apellido;
            usuarioExistente.Email = obj.Email;
            usuarioExistente.Rol = obj.Rol;
            usuarioExistente.EquipoId = obj.EquipoId;
            usuarioExistente.Validable();
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Usuario unUsuario = GetById(id);
            _context.Usuarios.Remove(unUsuario);
            _context.SaveChanges();
        }
    }
}
