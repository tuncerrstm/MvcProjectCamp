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
    public class MyAboutController : Controller
    {
        private MyAboutManager myAboutManager = new MyAboutManager(new EfMyAboutDal());
        // GET: MyAbout

        public ActionResult Index()
        {
            var result = myAboutManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MyAbout myAbout)
        {
            myAboutManager.Add(myAbout);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = myAboutManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(MyAbout myAbout)
        {
            myAboutManager.Update(myAbout);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = myAboutManager.GetById(id);
            myAboutManager.Delete(result);
            return RedirectToAction("Index");
        }
    }
}