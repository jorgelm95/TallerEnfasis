using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
  public  class compraCancionRepositorio
    {
            Taller2EnfasisContexto contexto;
            public compraCancionRepositorio(){
                contexto = new Taller2EnfasisContexto();
            }

            public void comprarCancion(compraCancion cancioncompra)
            {
                contexto.compraCanciones.Add(cancioncompra);
                contexto.SaveChanges();
            }
    }
}
