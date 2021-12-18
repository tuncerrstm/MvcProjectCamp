using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content


        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                var values = cm.GetList(p);
                return View(values.ToList());
            }
            else
            {
                var values = cm.GetList(p);
                //var values = c.Contents.ToList();
                return View(values);
            }
        }


        public ActionResult ContentByTitle(int id)
        {
            var contentValues = cm.GetListByTitleID(id);
            return View(contentValues);
        }
    }
}