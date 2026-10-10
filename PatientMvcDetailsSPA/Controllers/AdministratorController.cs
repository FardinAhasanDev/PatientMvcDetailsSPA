using PatientMvcDetailsSPA.DAL;
using PatientMvcDetailsSPA.Models;
using PatientMvcDetailsSPA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientMvcDetailsSPA.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            var roleList = new List<tbl_Role>();
            using (PatientDbContext db = new PatientDbContext())
            {
                roleList = db.tbl_Roles.ToList();
            }
            return View(roleList);
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(tbl_Role role)
        {
            if (ModelState.IsValid)
            {
                using (PatientDbContext db = new PatientDbContext())
                {
                    db.tbl_Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(role);
        }

        [HttpGet]
        public ActionResult UserList()
        {
            using (PatientDbContext db = new PatientDbContext())
            {
                var userList = db.tbl_Users.ToList();
                return View(userList);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (PatientDbContext db = new PatientDbContext())
            {
                var user = db.tbl_Users.SingleOrDefault(u => u.UserId == id);
                if (user == null) return HttpNotFound();

                var userRoles = db.tbl_UserRoles.Where(ur => ur.UserId == id);
                db.tbl_UserRoles.RemoveRange(userRoles);
                db.tbl_Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
        }

        [HttpGet]
        public ActionResult AssignRole(int id)
        {
            using (PatientDbContext db = new PatientDbContext())
            {
                var user = db.tbl_Users.Find(id);
                if (user == null) return HttpNotFound();

                var assignedRoleIds = db.tbl_UserRoles.Where(ur => ur.UserId == id).Select(ur => ur.RoleId).ToList();
                var viewModel = new ManageUserRoleViewModel
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserRoles = db.tbl_Roles.Select(r => new RoleCheckBoxSelection
                    {
                        RoleId = r.RoleId,
                        RoleName = r.RoleName,
                        IsAssigned = assignedRoleIds.Contains(r.RoleId)
                    }).ToList()
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignRole(ManageUserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (PatientDbContext db = new PatientDbContext())
                {
                    var existingRoles = db.tbl_UserRoles.Where(ur => ur.UserId == model.UserId);
                    db.tbl_UserRoles.RemoveRange(existingRoles);
                    if (model.UserRoles != null)
                    {
                        foreach (var role in model.UserRoles)
                        {
                            if (role.IsAssigned)
                            {
                                db.tbl_UserRoles.Add(new tbl_UserRole
                                {
                                    UserId = model.UserId,
                                    RoleId = role.RoleId,
                                });
                            }
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("UserList");
                }
            }
            return View(model);
        }
    }
}
