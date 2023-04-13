using MVC_Filters.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters.Controllers
{

    [ActFilter,ResFilter,AuthFilter,ExcFilter]
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            int s1 = 0;
            int s2 = 1 / s1;
            return View();
        }     
        public ActionResult Index2()
        {
            return View();
        }
    }
}