using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNotes.Entities;
using MyNotes.BusinessLayer;
using MyNotes.Entities.ValueObjects;
using MyNotes.Entities.Messages;

namespace MyNotes.WebApp.Controllers
{
    public class HomeController : Controller
    {        
        CategoryManager cm = new CategoryManager();
        NoteManager nm = new NoteManager();
        UserManager um = new UserManager();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //Validation(Kullanıcı taraflı) koşullarında bir sıkıntı yoksa 'true' döner.
            if (ModelState.IsValid)
            {
                var loginResult = um.LoginUser(model);

                if (loginResult.ErrorList.Count > 0)
                {
                    foreach (var item in loginResult.ErrorList)
                    {
                        ModelState.AddModelError("", item.Error);
                    }
                    return View(model);
                }
                // Session'a kullanıcı bilgileri saklanması.
                Session["login"] = loginResult.Result;
                // Yönlendirme.
                return RedirectToAction("Index");
            } 
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
            //Validation(Kullanıcı taraflı) koşullarında bir sıkıntı yoksa 'true' döner.
            if (ModelState.IsValid)     
            {
                var result = um.RegisterUser(model);

                if (result.ErrorList.Count > 0)
                {
                    foreach (var item in result.ErrorList)
                    {
                        ModelState.AddModelError("", item.Error);                        
                    }

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
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult UserActivate(Guid guid)
        {
            var ActivateResult = um.ActivateUser(guid);

            if (ActivateResult.ErrorList.Count > 0)
            {
                TempData["errors"] = ActivateResult.ErrorList;
                RedirectToAction("UserActivateCancel");
            }

            return RedirectToAction("UserActivateOk");
        }

        public ActionResult UserActivateOk()
        {

            return View();
        }

        public ActionResult UserActivateCancel()
        {
            if (TempData["errors"] != null)
            {
                List<ErrorMessageObj> ErrorList = (List<ErrorMessageObj>) TempData["errors"];

                return View(ErrorList);
            }

            return View();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    }
}