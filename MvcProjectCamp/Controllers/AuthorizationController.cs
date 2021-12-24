using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        
        public ActionResult Index()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminManager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetByID(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adminManager.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}