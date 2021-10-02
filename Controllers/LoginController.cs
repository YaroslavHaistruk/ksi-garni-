using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        IBookRepository repository;

        public LoginController(IBookRepository repo)
        {
            repository = repo;
        }
        EFDbContext context;

        



        public ViewResult Index()
        {
            return View(repository.Logins);
        }

        public ViewResult Edit(int loginId)
        {
            Login login = repository.Logins.FirstOrDefault(b => b.LoginId == loginId);

            return View(login);
        }

        [HttpPost]
        public ActionResult Edit(Login login)
        {
            if (ModelState.IsValid)
            {
                repository.Save(login);
                TempData["message"] = string.Format("Zmienianie informacji o loginie \"{0}\" zapisane", login.Imie);
                return RedirectToAction("Index");
            }
            else
            {
                return View(login);
            }
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View("Edit", new Login());
        }

        [HttpPost]
        public ActionResult Create(Login login)
        {
            if (ModelState.IsValid == true)
            {
                repository.Save(login);
                TempData["message"] = "Login został zapisany w bazie danych";

                return RedirectToAction("Index");
            }
            return View("Edit", login);
        }

        public ActionResult Delete(Login login)
        {
            login = repository.Logins.FirstOrDefault(p => p.LoginId != 0);
            if (ModelState.IsValid == true)
            {
                repository.DeleteLogin(login);
                TempData["message"] = "Login został usuwany z bazy danych";

                return RedirectToAction("Index");
            }
            return View("Delete", login);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var obj = db.Logins.Where(a => a.Imie.Equals(login.Imie) && a.Pass.Equals(login.Pass)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.LoginId.ToString();
                        Session["UserName"] = obj.Imie.ToString();
                        return RedirectToAction("Index","Admin");
                    }
                }
            }
            return View(login);
        }

   



















    }
}