using DataAccessLayer.EntityFramework;
using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        //private Context _context = new Context();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Software",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Travel",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Series",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Sports",
                CategoryCount = 1
            });
            return ct;
        }

        //public ActionResult CategoryPieChart()
        //{
        //    return View();
        //}
        //public ActionResult CategoryColumnChart()
        //{
        //    return View();
        //}
        //public ActionResult CategoryLineChart()
        //{
        //    return View();
        //}

        //public List<CategoryClass> CategoryListChart()
        //{
        //    List<CategoryClass> ct = new List<CategoryClass>();
        //    using (var _context = new Context())
        //    {
        //        ct = _context.Categories.Select(x => new CategoryClass
        //        {
        //            CategoryName = x.CategoryName,
        //            CategoryCount = x.CategoryName.Length
        //        }).ToList();
        //    }

        //    return ct;
        //}

        //public ActionResult VisualizeByCategory()
        //{
        //    return Json(CategoryListChart(), JsonRequestBehavior.AllowGet);
        //}
    }
}