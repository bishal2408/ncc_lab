using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSystem.Models;

namespace LoginSystem.Controllers
{
    public class LoginController : Controller
    {
        db_loginEntities db = new db_loginEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(login l)
        {
            if (ModelState.IsValid == true)
            {
                var data = db.logins.Where(x=>x.username == l.username && x.password == l.password).FirstOrDefault();
                if (data == null)
                {
                    ViewBag.Message = "error username and password";
                    return View();
                }
                else
                {
                    Session["username"] = l.username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}