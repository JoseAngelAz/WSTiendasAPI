using System;
using System.Collections.Generic;

#nullable disable

namespace WSTiendas.Models
{
    public partial class Tienda
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
