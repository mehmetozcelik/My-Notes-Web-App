using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNotes.Entities;
using MyNotes.BusinessLayer;
using MyNotes.Entities.ValueObjects;

namespace MyNotes.WebApp.Controllers
{
    public class HomeController : Controller
    {        
        CategoryManager cm = new CategoryManager();
        NoteManager nm = new NoteManager();
        UserManager um = new UserManager();

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

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            MyNotesUser user = null;
            MyNotesUser user2 = null;

            //Validation koşullarında bir sıkıntı yoksa true döner.
            if (ModelState.IsValid)     
            {
                try
                {
                    user = um.RegisterUserTest1(model);
                    user2 = um.RegisterUserTest1(model);
                }
                catch (Exception ex)
                {
                    //Validation error'larına controllerden error ekleme.
                    ModelState.AddModelError("", ex.Message);
                }

                if (user != null || user2 != null)
                {
                    return View(model);
                }
                return RedirectToAction("RegisterOk");
            }
            return View(model);           
        }

        public ActionResult RegisterOk()
        {
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


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////


    }
}