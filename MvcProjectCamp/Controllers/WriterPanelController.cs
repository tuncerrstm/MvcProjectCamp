using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        Context c = new Context();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyTitle(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIDinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = tm.GetListByWriter(writerIDinfo);
            return View(values);
        }

        
        [HttpGet]
        public ActionResult NewTitle()
        {
            
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewTitle(Title p)
        {
            string emailValue = (string)Session["WriterMail"];
            var writerIDinfo = c.Writers.Where(x => x.WriterMail == emailValue).Select(y => y.WriterID).FirstOrDefault();
            p.TitleDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.WriterID = writerIDinfo;
            p.TitleStatus = true;
            tm.TitleAdd(p);
            return RedirectToAction("MyTitle");
        }

        [HttpGet]
        public ActionResult EditTitle(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            var TitleValue = tm.GetByID(id);
            return View(TitleValue);
        }

        [HttpPost]
        public ActionResult EditTitle(Title p)
        {
            tm.TitleUpdate(p);
            return RedirectToAction("MyTitle");
        }

        public ActionResult DeleteTitle(int id)
        {
            var TitleValue = tm.GetByID(id);
            TitleValue.TitleStatus = false;
            tm.TitleDelete(TitleValue);
            return RedirectToAction("MyTitle");
        }
    }
}