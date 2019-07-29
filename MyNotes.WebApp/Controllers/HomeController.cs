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
        CategoryManager cm = new CategoryManager();
        NoteManager nm = new NoteManager();

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        

        public ActionResult Index()
        {             
            return View();
        }

        public PartialViewResult PartialNotes()
        {
            List<Note> list = nm.GetNotes();
            
            return PartialView("_PartialNotes", list);
        }


        public PartialViewResult CategorySelect(int? id)
        {
            List<Note> list=null;

            if (id != null)
            {
                list = nm.GetNotesParam(id);               
            }
            return PartialView("_PartialNotes", list);
        }

        public ActionResult CategoryName(int id)
        {
            Category category = cm.FindCategory(id);

            return View("Index",category);
        }

    }
    
}