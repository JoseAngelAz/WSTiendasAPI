using System;
using System.Collections.Generic;

#nullable disable

namespace WSTiendas.Models
{
    public partial class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long TipoUsuario { get; set; }
        public string Email { get; set; }
    }
}
