using ProjectWeb_1.Metodos;
using ProjectWeb_1.Models.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWeb_1.Controllers
{
    public class TipoPropiedadController : Controller
    {
        // GET: TipoPropiedad
        [HttpGet]
        public JsonResult ListarTipoPropiedad()
        {
            List<TipoPropiedad> oLista = new List<TipoPropiedad>();

            oLista = TipoPropiedadMetodo.Instancia.Listar();

            //se retorna la lista en formato Json
            return Json(new {data = oLista}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoPropiedad (TipoPropiedad objeto)
        {
            bool respuesta = false;

            respuesta = (objeto.IdTipoPropiedad == 0)
                ? TipoPropiedadMetodo.Instancia.Registrar(objeto)
                :TipoPropiedadMetodo.Instancia.Modificar(objeto);

            return Json(new { data = objeto }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoPropiedad(int id)
        {
            bool respuesta = false;

           

            return Json(new { data = objeto }, JsonRequestBehavior.AllowGet);
        }
    }
}