using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        TitleManager tm = new TitleManager(new EfTitleDal());

        public ActionResult Titles()
        {
            var titleList = tm.GetList();
            return View(titleList);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}