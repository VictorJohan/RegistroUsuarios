using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroUsuario.Entidades
{
   public class Usuarios
    {
        [Key]
        public string IdUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }

    }
}
