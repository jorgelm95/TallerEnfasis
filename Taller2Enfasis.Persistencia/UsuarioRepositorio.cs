using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
  public  class UsuarioRepositorio
    {

      private Taller2EnfasisContexto contexto; 

    public UsuarioRepositorio()
      {
          contexto = new Taller2EnfasisContexto();
      }

      public void guardarUsuario(Usuario usuario)
      {

          this.contexto.Usuarios.Add(usuario);
          contexto.SaveChanges();
           
      }

      public void guardarAdministrador(Usuario administrador)
      {
          administrador.TipoUsuario = TipoUsuario.Administrador;
          contexto.Usuarios.Add(administrador);
          contexto.SaveChanges();
      }

      public Usuario validarUsuario(string username, string password)
      {  

          Usuario usuario = contexto.Usuarios.FirstOrDefault(u => u.Username == username && u.Password == password);
          return usuario;
      }


      public Usuario ValidarUsername(string username)
      {
          Usuario usuario = contexto.Usuarios.FirstOrDefault(u => u.Username == username);
          return usuario;
      }

      public Usuario consultarUsuarioPorId(int idUsuario)
      {
          Usuario usuarioDetalle = contexto.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
          return usuarioDetalle;
      }


      public void ModificarUsuario(Usuario usuario)
      {

          Usuario usuarioModificar = consultarUsuarioPorId(usuario.Id);
          
          usuarioModificar.Nombres = usuario.Nombres;
          usuarioModificar.Apellidos = usuario.Apellidos;
          usuarioModificar.FechaNacimiento = usuario.FechaNacimiento;
          usuarioModificar.Sexo = usuario.Sexo;
          usuarioModificar.Correo = usuario.Correo;
          usuarioModificar.Password = usuario.Password;

          contexto.SaveChanges();

      }

      public void eliminarUsuario(Usuario usuario)
      {
          Usuario usuarioEliminar = contexto.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
          contexto.Usuarios.Remove(usuarioEliminar);
          contexto.SaveChanges();
      }

    }   
}
