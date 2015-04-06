using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
   public  class compraCancion
    {
        public int Id { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Cancion cancion { get; set; }

    }
}
