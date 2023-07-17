using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proje.Controllers
{
    public class AboutController : Controller
    {

        AboutManager am = new AboutManager(new EFAboutDal());

        public ActionResult Index()
        {
            var aboutValue = am.GetList();
            return View(aboutValue);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}