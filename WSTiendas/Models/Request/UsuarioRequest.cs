using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTiendas.Models.Request
{
    public class UsuarioRequest
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoUsuario { get; set; }
        public string Email { get; set; }
    }
}
