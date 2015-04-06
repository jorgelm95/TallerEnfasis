using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
    public class CancionRepositorio
    {
        Taller2EnfasisContexto contexto;
        public CancionRepositorio()
        {
            contexto = new Taller2EnfasisContexto();
        }

        public void GuardarCancion(Cancion cancion)
        {

            var disco = contexto.Discos.FirstOrDefault(d => d.Id == cancion.idDisco);
            cancion.album = disco;
            contexto.Canciones.Add(cancion);
            contexto.SaveChanges();
        }

        public void ModificarCancion(Cancion cancion)
        {
            Cancion cancionModificar = contexto.Canciones.FirstOrDefault(c => c.Id == cancion.Id);
            cancionModificar.NombreCacion = cancion.NombreCacion;
            cancionModificar.Duracion = cancion.Duracion;
            cancionModificar.Precio = cancion.Precio;
            cancion.album = cancion.album;
            contexto.SaveChanges();
        }

        public Cancion consultarCancionId(int idCancion)
        {
            Cancion cancion = contexto.Canciones.FirstOrDefault(d => d.Id == idCancion);
            return cancion;
        }


        public List<Cancion> listaCanciones()
        {
            List<Cancion> listaCanciones = contexto.Canciones.ToList();
            return listaCanciones;
        }

        public List<Cancion> cancionesRecomendadas()
        {
            List<Cancion> canciones = contexto.Canciones.Where (c => c.Precio >= 1000 && c.Precio < 5000).ToList();
            return canciones;
        }

        public List<Cancion> BuscarCanciones(string opcion, string PalabraClave)
        {
            List<Cancion> cancionesEncontradas = new List<Cancion>();

            if (opcion == "album")
            {

                Disco disco = contexto.Discos.FirstOrDefault(d => d.Nombre == PalabraClave);
                int disco_album = disco.Id;

                cancionesEncontradas = contexto.Canciones.Where(c => c.album.Id == disco_album).ToList();
                return cancionesEncontradas;

            }
            else if (opcion == "Artista")
            {
                Artista artista = contexto.Artistas.FirstOrDefault(a => a.Nombres == PalabraClave);
                int id_artista = artista.Id;

                List<Disco> discosArtista = contexto.Discos.Where(d => d.artista.Id == id_artista).ToList();

                foreach (var item in discosArtista)
                {
                    List<Cancion> canciones = contexto.Canciones.ToList();
                    foreach (var itenCancion in canciones)
                    {


                        if (item.Id == itenCancion.album.Id)
                        {
                            cancionesEncontradas.Add(itenCancion);
                        }
                    }

                    return cancionesEncontradas.ToList();
                }

            }
            else if (opcion == "Genero")
            {
                cancionesEncontradas = contexto.Canciones.Where(c => c.album.Genero == PalabraClave).ToList();
                return cancionesEncontradas.ToList();
            }

            return cancionesEncontradas.ToList();
        }

        public void EliminarCancion(int idCancion)
        {
            Cancion cancionEliminar = consultarCancionId(idCancion);
            contexto.Canciones.Remove(cancionEliminar);
            contexto.SaveChanges();

        }
    }
}
