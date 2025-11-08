using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWeb_1.Models.ViewModel
{
    public class TipoPropiedad
    {
        public int IdTipoPropiedad { get; set; }
        public string Descripcion { get; set; }
        public bool Activo {  get; set; }
    }
}