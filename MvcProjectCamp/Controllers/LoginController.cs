using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());

        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if(adminUserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writerUserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            var writerUserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writerUserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserinfo.WriterMail, false);
                Session["WriterMail"] = writerUserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Titles", "Default");
        }
    }
}