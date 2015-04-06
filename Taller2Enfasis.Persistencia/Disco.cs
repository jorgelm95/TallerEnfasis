using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
   public class Disco
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string Nombre { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int NumeroCanciones { get; set; }
        public string Genero { get; set; }
        public int Precio { get; set; }
        [NotMapped]
        public int IdArtista { get; set; }

        public virtual Artista artista { get; set; }
        public virtual List<Cancion> Canciones { get; set; }
    }
}
