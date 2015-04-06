using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
    public class ArtistaRepositorio
    {
        Taller2EnfasisContexto contexto;
        public ArtistaRepositorio()
        {
            contexto = new Taller2EnfasisContexto();
        }

        public void GuardarArtista(Artista artista)
        {
            contexto.Artistas.Add(artista);
            contexto.SaveChanges();
        }


        public List<Artista> listaArtistas()
        {
            List<Artista> listaArtista = contexto.Artistas.ToList();
            return listaArtista;
        }

        public Artista consultarArtistaId(int id)
        {
            Artista artista = contexto.Artistas.FirstOrDefault(a => a.Id == id);
            return artista;
        }

        public void ModificarArtista(Artista artista)
        {
            Artista artistaModificar = consultarArtistaId(artista.Id);

            artistaModificar.Nombres = artista.Nombres;
            artistaModificar.UrlFoto = artista.UrlFoto;
            contexto.SaveChanges();
        }

        public void EliminarArtista(int Id)
        {
            Artista artistaEliminar = contexto.Artistas.FirstOrDefault(a => a.Id == Id);
            contexto.Artistas.Remove(artistaEliminar);

            contexto.SaveChanges();

        }
    }
}