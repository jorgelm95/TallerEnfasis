using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
    public class DiscoRepositorio
    {
        Taller2EnfasisContexto contexto;

        public DiscoRepositorio()
        {
            contexto = new Taller2EnfasisContexto();
        }

        public void GuardarDisco(Disco disco)
        {
            var artista = contexto.Artistas.FirstOrDefault(a => a.Id == disco.IdArtista);
            disco.artista = artista;
            contexto.Discos.Add(disco);
            contexto.SaveChanges();

        }

        public List<Disco> listardiscos()
        {
            List<Disco> discos = contexto.Discos.ToList();
            return discos;
        }

        public Disco consultarDiscoId(int idDisco)
        {
            Disco disco = contexto.Discos.FirstOrDefault(d => d.Id == idDisco);
            return disco;
        }


        public void ModificarDisco(Disco disco)
        {
            Disco discoModificar = contexto.Discos.FirstOrDefault(d => d.Id == disco.Id);
            discoModificar.Nombre = disco.Nombre;
            discoModificar.UrlFoto = disco.UrlFoto;
            discoModificar.FechaLanzamiento = disco.FechaLanzamiento;
            discoModificar.NumeroCanciones = disco.NumeroCanciones;
            discoModificar.Precio = disco.Precio;

            contexto.SaveChanges();

        }

        public void EliminarDisco(int iddisco)
        {
            Disco discoEliminar = consultarDiscoId(iddisco);
            contexto.Discos.Remove(discoEliminar);
            contexto.SaveChanges();
        }

        public List<Disco> DiscosSugeridos()
        {
            List<Disco> discos = contexto.Discos.ToList();
            List<Disco> discosSugeridos = new List<Disco>();
            foreach (var item in discos)
            {
                Random idAleatorio = new Random();

                int id = Convert.ToInt32(idAleatorio.Next(1, 7));

                if ((item.Id % id) != 0)
                {
                    if (discosSugeridos.Count() <= 2)
                    {
                        discosSugeridos.Add(item);
                    }
                }
            }

            return discosSugeridos.ToList();
        }
    }
}
