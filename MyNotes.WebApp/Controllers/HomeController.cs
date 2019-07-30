using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNotes.Entities;
using MyNotes.BusinessLayer;
using MyNotes.WebApp.ViewModels;

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
            List<Note> list = nm.GetNotes().OrderByDescending(x => x.ModifiedOn).ToList();

            return PartialView("_PartialNotes", list);
        }


        public PartialViewResult CategorySelect(int? id)
        {
            List<Note> list = null;

            if (id != null)
            {
                list = nm.GetNotesParam(id).OrderByDescending(x => x.ModifiedOn).ToList();
            }
            return PartialView("_PartialNotes", list);
        }

        public PartialViewResult CategoryName(int id)
        {
            Category category = cm.FindCategory(id);
            
            return PartialView("_PartialHeaderCategory", category);
        }

        public PartialViewResult MostLike()
        {
            List<Note> list = nm.GetNotes().OrderByDescending(x => x.LikeCount).ToList();
            return PartialView("_PartialNotes", list);
        }
        
        public ActionResult About()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //Giriş kontrolü ve yönlendirme.
            //Session'a kullanıcı bilgileri saklanması.
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //Kullanıcı e-mail ve username kotrolü.
            //Kayıt işlem.
            //Activasyon e-postası gönderimi.
            return View();
        }


        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult UserActivate(Guid guid)
        {
            //Kullanıcı aktivasyonu  sağlanacak.
            return View();
        }

    }
}