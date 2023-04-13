using MVC_Filters.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters.Filters
{
    public class ResFilter : FilterAttribute, IResultFilter
    {
        DatabaseContext db = new DatabaseContext();
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["login"];

            string username = "noname";

            if (user != null)
            {
                username = user.KullaniciAdi;
            }

            db.Logs.Add(new Log()
            {
                KullaniciAdi =username,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Tarih = DateTime.Now,
                Aciklama = "View Executed"
            });
            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Kullanici user = (Kullanici)filterContext.HttpContext.Session["login"];
            string username = "noname";

            if (user != null)
            {
                username = user.KullaniciAdi;
            }

            db.Logs.Add(new Log()
            {
                KullaniciAdi = username,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Tarih = DateTime.Now,
                Aciklama = "View Executing"
            });
            db.SaveChanges();
        }
    }
}