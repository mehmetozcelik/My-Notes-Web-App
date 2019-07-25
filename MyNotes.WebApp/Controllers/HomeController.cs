using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNotes.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            BusinessLayer.Test db = new BusinessLayer.Test();
            
            return View();
        }

    }
}