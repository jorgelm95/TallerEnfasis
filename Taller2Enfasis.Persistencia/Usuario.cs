using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2Enfasis.Persistencia
{
   public class Usuario
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Nombres { get; set; }
        [StringLength(40)]
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [StringLength(30)]
        public string Sexo { get; set; }
        public string Correo { get; set; }
        [StringLength(15)]
        public string Username { get; set; }
        [StringLength(15)]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmacionPassword { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
    }
}
