using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller2Enfasis.Persistencia;

namespace Taller2Enfasis.web.Controllers
{
    public class ArtistaController : Controller
    {
        ArtistaRepositorio artistaRepo = new ArtistaRepositorio();
        // GET: Artista
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuardarArtista()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarArtista(Artista artista)
        {

            if (!string.IsNullOrEmpty(artista.Nombres) && !string.IsNullOrEmpty(artista.UrlFoto)){
                artistaRepo.GuardarArtista(artista);
                List<Artista> artistas = artistaRepo.listaArtistas();
                ViewBag.Artista = "artista publicado con exito";
                return View();
            }
            else
            {
                ViewBag.Error = "llene todos los campos porfavot";
                return View();
            }
            


        }
        public ActionResult EditarArtista(int id)
        {

            Artista artista = artistaRepo.consultarArtistaId(id);
            return View(artista);
        }

        [HttpPost]
        public ActionResult EditarArtista(Artista artista)
        {


            artistaRepo.ModificarArtista(artista);
            List<Artista> artistas = artistaRepo.listaArtistas();
            return View("Index", artistas);
        }

        public ActionResult EliminarArtista(int id)
        {

            artistaRepo.EliminarArtista(id);
            List<Artista> artistas = artistaRepo.listaArtistas();
            return View("Index", artistas);

        }

    }
}