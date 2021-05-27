using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context context = new Context();

        public ActionResult Index()
        {
            var getCategory = context.Categories.Count().ToString();
            ViewBag.getcategory = getCategory;

            var getSoftware = context.Titles.Count(x => x.Category.CategoryID == 8);
            ViewBag.software = getSoftware;

            var getWriter = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.writer = getWriter;

            var getTitle = context.Titles.Max(x => x.Category.CategoryName);
            ViewBag.title = getTitle;

            var trueData = context.Categories.Count(x => x.CategoryStatus == true);

            var falseData = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.status = (trueData - falseData);

            return View();
        }
    }
}