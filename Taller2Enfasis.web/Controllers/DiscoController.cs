using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taller2Enfasis.Persistencia;

namespace Taller2Enfasis.web.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        DiscoRepositorio discoRepo = new DiscoRepositorio();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuardarDisco(int IdArtista)
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarDisco(Disco disco)
        {
            if (!string.IsNullOrEmpty(disco.Nombre) && !string.IsNullOrEmpty(disco.UrlFoto)    
                && !string.IsNullOrEmpty(disco.Genero))
            {
                discoRepo.GuardarDisco(disco);
                return RedirectToAction("AgregarDiscos", "Administrador", new { id = disco.IdArtista });
            }
            else
            {
                ViewBag.ErrorDisco = "llene todos los campos del disco";
                return View();
            }
            
            
        }

        public ActionResult EditarDisco(int idDisco)
        {
            Disco disco = discoRepo.consultarDiscoId(idDisco);
            return View(disco);
        }

        [HttpPost]
        public ActionResult EditarDisco(Disco disco)
        {

            discoRepo.ModificarDisco(disco);
            List<Disco> listaDiscos = discoRepo.listardiscos();
            return RedirectToAction("listaDiscos", listaDiscos);
        }


        public ActionResult listaDiscos()
        {
            List<Disco> lDiscos = discoRepo.listardiscos();
            return View(lDiscos);
        }

        public ActionResult EliminarDisco(int idDisco)
        {
            discoRepo.EliminarDisco(idDisco);
            List<Disco> listaDiscos = discoRepo.listardiscos();
            return RedirectToAction("listaDiscos", listaDiscos);
        }

        public ActionResult DiscosSugeridos()
        {
            List<Disco> discosSugeridos = discoRepo.DiscosSugeridos();
            return PartialView(discosSugeridos);
        }
    }
}