using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
  public class Artista
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombres { get; set; }
        public string UrlFoto { get; set; }

        public virtual List<Disco> discos { get; set; }
    }
}
