using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        TitleManager tm = new TitleManager(new EfTitleDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Titles()
        {
            var titleList = tm.GetList();
            return View(titleList);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentList = cm.GetListByTitleID(id);
            return PartialView(contentList);
        }
    }
}