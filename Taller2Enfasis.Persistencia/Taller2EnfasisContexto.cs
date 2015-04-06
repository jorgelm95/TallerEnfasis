using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
    public class Taller2EnfasisContexto : DbContext
    {

        public Taller2EnfasisContexto() : base("Taller2Enfasis")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Disco> Discos { get; set; }
    }
}
