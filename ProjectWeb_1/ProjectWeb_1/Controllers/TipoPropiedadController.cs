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
            #region prueba

            try
            {
                var tiposPropiedad = TipoPropiedadMetodo.Instancia.Listar();
                return Json(new { data = tiposPropiedad }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new {resultado = false, mensaje = "Data invalida"});
            }

            #endregion

            //List<TipoPropiedad> oLista = new List<TipoPropiedad>();

            //oLista = TipoPropiedadMetodo.Instancia.Listar();

            ////se retorna la lista en formato Json
            //return Json(new {data = oLista}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoPropiedad (TipoPropiedad objeto)
        {
            if(!ModelState.IsValid)
            {
                return Json(new { resultado = false, mensaje = "Data invalida" });
            }
            #region prueba
            try
            {
                bool respuesta = (objeto.IdTipoPropiedad == 0)
                ? TipoPropiedadMetodo.Instancia.Registrar(objeto)
                :TipoPropiedadMetodo.Instancia.Modificar(objeto);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {

                return Json(new {resultado = false, mensaje = ex.Message});
            }
            #endregion

            //bool respuesta = (objeto.IdTipoPropiedad == 0)
            //    ? TipoPropiedadMetodo.Instancia.Registrar(objeto)
            //    :TipoPropiedadMetodo.Instancia.Modificar(objeto);

            //return Json(new { data = objeto }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoPropiedad(int id)
        {
            bool respuesta = false;

           respuesta = TipoPropiedadMetodo.Instancia.Eliminar(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}