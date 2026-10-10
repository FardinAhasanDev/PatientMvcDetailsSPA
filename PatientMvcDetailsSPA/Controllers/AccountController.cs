using PatientMvcDetailsSPA.DAL;
using PatientMvcDetailsSPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PatientMvcDetailsSPA.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account/Signup
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(tbl_User user)
        {
            if (ModelState.IsValid)
            {
                using (PatientDbContext db = new PatientDbContext())
                {
                    var exists = db.tbl_Users.Any(u => u.UserName == user.UserName);
                    if (exists)
                    {
                        ModelState.AddModelError("", "This user name is already taken.");
                        return View(user);
                    }
                    db.tbl_Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            return View(user);
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tbl_User user)
        {
            if (user != null)
            {
                using (PatientDbContext db = new PatientDbContext())
                {
                    var count = db.tbl_Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).Count();
                    if (count <= 0)
                    {
                        ViewBag.Message = "Invalid UserName or Password";
                        return View();
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("Index", "Patients");
                    }
                }
            }
            ViewBag.Message = "Invalid request";
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
