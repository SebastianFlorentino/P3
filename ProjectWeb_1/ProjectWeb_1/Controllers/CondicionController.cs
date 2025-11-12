using Newtonsoft.Json;
using ProjectWeb_1.Metodos;
using ProjectWeb_1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWeb_1.Controllers
{
    public class CondicionController : Controller
    {
        // GET: Condicion
        public ActionResult Condicion()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ConsultaCondicion()
        {
            List<CondicionViewModel> obj = new List<CondicionViewModel>();
            obj = CondicionMetodo.Instancia.Consultar();

            return Json(new {data = obj}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCondicion(CondicionViewModel obj)
        {
            bool respuesta = false;

            respuesta = (obj.IdCondicion == 0)
                ? CondicionMetodo.Instancia.Registrar(obj)
                : CondicionMetodo.Instancia.Modificar(obj);

            return Json(new { data = obj }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCondicion(int Id)
        {
            bool respuesta = false;

            respuesta = CondicionMetodo.Instancia.Eliminar(Id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}