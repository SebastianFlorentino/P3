using ProjectWeb_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWeb_1.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string username, string password)
        {
            using(DBMVCEntities db =  new DBMVCEntities())
            {
                var read = from d in db.USERS
                           where d.Email == username && d.Password == password && d.idEstatus == 1
                           select d;

                if (read.Count()  > 0)
                {
                    Session["Usuario"] = read.First();
                    return Content("1");
                }
                else
                {
                    return Content("Ocurrio un error, revisa el usuario y/o contraseña");
                }
            }
        }
    }
}