using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller2Enfasis.Persistencia;

namespace Taller2Enfasis.web.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioRepositorio repositorioUsuario = new UsuarioRepositorio();
        // GET: Usuario
        public ActionResult Index()
        {
            Usuario usuario = Session["usuarioLogueado"] as Usuario;
            ViewBag.NombreUsuario = usuario.Nombres;
            ViewBag.idUsuario = usuario.Id;

            int tipousuario = Convert.ToInt32(usuario.TipoUsuario);

            if (tipousuario == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IndexAdministrador", "Administrador");
            }
        }

        public ActionResult GuardarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarUsuario(Usuario usuario)
        {

            string username = usuario.Username;
            Usuario usernameValidar = repositorioUsuario.ValidarUsername(username);

            if (usernameValidar == null)
            {
                repositorioUsuario.guardarUsuario(usuario);
                ViewBag.UsuarioCreado = "Su registro se completo satisfactoriamente";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.UsernameDuplicado = "El username ya existe escoja otro";
                return RedirectToAction("Index", "Home");

            }
        }


        public ActionResult validarUsuario(string username, string password)
        {
            UsuarioRepositorio repo = new UsuarioRepositorio();


            Usuario usuarioValidado = repo.validarUsuario(username, password);
            if (usuarioValidado == null)
            {
                ViewBag.MensajeError = "El usuario no exixte, intente nuevamente";
                return View("Login");
            }
            else
            {
                Session["usuarioLogueado"] = usuarioValidado;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult DetalleUsuario(int id)
        {
            Usuario usuario = repositorioUsuario.consultarUsuarioPorId(id);
            return View(usuario);
        }


        public ActionResult EditarDatosUsuario(int idUsuario)
        {
            Usuario usuario = repositorioUsuario.consultarUsuarioPorId(idUsuario);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarDatosUsuario(Usuario usuario)
        {
            repositorioUsuario.ModificarUsuario(usuario);
            return RedirectToAction("Index", "Usuario");
        }

    }
}