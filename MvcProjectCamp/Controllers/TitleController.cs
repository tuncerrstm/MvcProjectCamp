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
    public class TitleController : Controller
    {
        // GET: Title

        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var titleValues = tm.GetList();
            return View(titleValues);
        }

        [HttpGet]
        public ActionResult AddTitle()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddTitle(Title p)
        {
            p.TitleDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            tm.TitleAdd(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTitle(int id)
        {
            var TitleValue = tm.GetByID(id);
            TitleValue.TitleStatus = false;
            tm.TitleDelete(TitleValue);
            return RedirectToAction("Index");
        }
    }
}