using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllTitles", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

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

        public ActionResult AllTitles(int page = 1)
        {
            var titles = tm.GetList().ToPagedList(page, 5);
            return View(titles);
        }
    }
}