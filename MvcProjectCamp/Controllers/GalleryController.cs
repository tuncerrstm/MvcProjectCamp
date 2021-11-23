using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFilesManager ifm = new ImageFilesManager(new EfImageFilesDal());

        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}