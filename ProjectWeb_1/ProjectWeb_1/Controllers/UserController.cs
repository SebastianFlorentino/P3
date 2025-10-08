using ProjectWeb_1.Models;
using ProjectWeb_1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWeb_1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Query()
        {
            List<QueryViewModel> list = null;

            using (DBMVCEntities db = new DBMVCEntities())
            {
                list = (from d in db.USERS
                        where d.idEstatus == 1
                        orderby d.Email
                        
                        select new QueryViewModel
                        {
                            Email = d.Email,
                            Id = d.ID,
                            Edad = d.Edad
                        }).ToList();
            }

            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddUsersViewModel model)
        {
            if(ModelState.IsValid)
            {
                return View(model);
            }

            using(var db  = new DBMVCEntities())
            {
                USERS tabla = new USERS();

                tabla.idEstatus = 1;
                tabla.Nombre = model.Nombre;
                tabla.Email = model.Email;
                tabla.Edad = model.Edad;
                tabla.Password = model.Contrasenna;

                db.USERS.Add(tabla);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditUsersViewModel model = new EditUsersViewModel();

            using (var db  = new DBMVCEntities())
            {
                var tabla = db.USERS.Find(id);

                model.Id = tabla.ID;
                model.Nombre = tabla.Nombre;
                model.Email = tabla.Email;
                model.Edad = tabla.Edad;
                model.Contrasenna = tabla.Password;

                return View(model);
            }

            
        }

        [HttpPost]
        public ActionResult Edit(EditUsersViewModel model)
        {
            using (var db = new DBMVCEntities()) 
            {
                var tabla = db.USERS.Find(model.Id);

                tabla.Nombre = model.Nombre;
                tabla.Email = model.Email;
                tabla.Edad = model.Edad;

                if(model.Contrasenna != null || model.Contrasenna != "")
                {
                    tabla.Password = model.Contrasenna;
                }

                db.Entry(tabla).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpPost]
        public ActionResult OcultarRegistro(int id)
        {
            using(var db = new DBMVCEntities())
            {
                var tabla = db.USERS.Find(id);

                tabla.idEstatus = 3;

                db.Entry(tabla).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}