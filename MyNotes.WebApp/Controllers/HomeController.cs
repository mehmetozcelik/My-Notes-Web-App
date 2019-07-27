using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNotes.Entities;
using MyNotes.BusinessLayer;

namespace MyNotes.WebApp.Controllers
{
    public class HomeController : Controller
    {
        BusinessLayer.Test test = new BusinessLayer.Test();

        public ActionResult Index()
        {
            //test.ListTest();
            test.ListTest2();
            //test.InsertTest();
            //test.UpdateTest();

            return View();
        }

    }
}