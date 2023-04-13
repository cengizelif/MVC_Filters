using MVC_Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Kullanici model)
        {
            DatabaseContext db = new DatabaseContext();
            
            Kullanici kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);

            if(kullanici==null)
            {
                ModelState.AddModelError("", "Kullanıcı adı yada şifre hatalı");
                return View(model);
            }
            else
            {
                Session["login"] = kullanici;
                return RedirectToAction("Index", "Home");
            }

          
        }

        public ActionResult Error()
        {
            if (TempData["error"]==null)
            {
                return RedirectToAction("Index", "Home");
            }

            Exception model =(Exception) TempData["error"];

            return View(model);
        }
    }
}