using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller2Enfasis.Persistencia;

namespace Taller2Enfasis.web.Controllers
{
    public class CancionController : Controller
    {
        // GET: Cancion
        CancionRepositorio RepoCancion = new CancionRepositorio();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuardarCancion(int Iddisco)
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarCancion(Cancion cancion)
        {
            if (!string.IsNullOrEmpty(cancion.NombreCacion) && !string.IsNullOrEmpty(cancion.Duracion)){

                RepoCancion.GuardarCancion(cancion);
                return RedirectToAction("AgregarCaciones", "Administrador", new { idDisco = cancion.idDisco });
            }
         
            ViewBag.ErrorCancion = "llene todos los campos de la cancion";
            return View();
        }

        public ActionResult ListarCanciones()
        {
            List<Cancion> listaCancionesRecomendadas = RepoCancion.cancionesRecomendadas();
            return PartialView(listaCancionesRecomendadas);
        }

        public ActionResult listaCanciones()
        {
            List<Cancion> listaCanciones = RepoCancion.listaCanciones();
            return View(listaCanciones);
        }

        public ActionResult ObtenerCaciones(string opcion, string palabraClave)
        {
            List<Cancion> cancionesEncontradas = RepoCancion.BuscarCanciones(opcion, palabraClave);
            return View(cancionesEncontradas);
        }


        public ActionResult EditarCancion(int idCancion)
        {
            Cancion cancion = RepoCancion.consultarCancionId(idCancion);
            return View(cancion);
        }

        [HttpPost]
        public ActionResult EditarCancion(Cancion cancion)
        {
            RepoCancion.ModificarCancion(cancion);
            List<Cancion> canciones = RepoCancion.listaCanciones();
            return RedirectToAction("listaCanciones",canciones);
        }

        public ActionResult EliminarCancion(int idCancion)
        {
            RepoCancion.EliminarCancion(idCancion);
            List<Cancion> listaCanciones = RepoCancion.listaCanciones();
            return RedirectToAction("listaCanciones", listaCanciones);

        }

        public ActionResult DetalleCancion(int id)
        {
            Cancion cancion = RepoCancion.consultarCancionId(id);
            return View(cancion);
        }



    }
}