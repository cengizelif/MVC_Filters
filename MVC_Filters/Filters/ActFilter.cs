using MVC_Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters.Filters
{
    public class ActFilter : FilterAttribute, IActionFilter
    {
        DatabaseContext db = new DatabaseContext();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["login"];

            string username = "noname";
            if (user != null)
            {
                username = user.KullaniciAdi;
            }

            db.Logs.Add(new Log()
            {          
                KullaniciAdi=username,              ActionName=filterContext.ActionDescriptor.ActionName,                ControllerName=filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Tarih=DateTime.Now,
                Aciklama="Action Executed"
            });
            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["login"];

            string username = "noname";

            if (user != null)
            {
                username =user.KullaniciAdi ;
            }
       


            db.Logs.Add(new Log()
            {
                KullaniciAdi =username,
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Tarih = DateTime.Now,
                Aciklama = "Action Executing"
            });
            db.SaveChanges();
        }
    }
}