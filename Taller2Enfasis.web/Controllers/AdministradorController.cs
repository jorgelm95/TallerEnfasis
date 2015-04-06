using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller2Enfasis.Persistencia;

namespace Taller2Enfasis.web.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        ArtistaRepositorio artistaRepo = new ArtistaRepositorio();
        DiscoRepositorio discoRepo = new DiscoRepositorio();
        UsuarioRepositorio usuarioRepo = new UsuarioRepositorio();
        public ActionResult IndexAdministrador()
        {
            Usuario usuario = Session["usuarioLogueado"] as Usuario;
            int tipouser = Convert.ToInt32(usuario.TipoUsuario);
            if (tipouser == 1)
            {

                List<Artista> artistas = artistaRepo.listaArtistas();
                ViewBag.Administrador = usuario.Nombres;
                return View(artistas);

            }
            else
            {
                return Content("no eres administrador de la pagina no puede entrar");
            }

        }

        public ActionResult CrearAdministrador()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearAdministrador(Usuario administrador)
        {

            usuarioRepo.guardarAdministrador(administrador);
            return RedirectToAction("IndexAdministrador");
        }

        public ActionResult AgregarDiscos(int id)
        {

            Artista artista = artistaRepo.consultarArtistaId(id);
            return View(artista);

        }

        public ActionResult AgregarCaciones(int idDisco)
        {
            Disco disco = discoRepo.consultarDiscoId(idDisco);
            return View(disco);
        }
    }
}