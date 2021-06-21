using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManger abm = new AboutManger(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPatial()
        {
            return PartialView();


        }

        public ActionResult AktifPasif(int id)
        {
            var AboutValue = abm.GetByID(id);
            if (AboutValue.AboutStatus == true)
            {
                AboutValue.AboutStatus = false;
            }
            else
            {
                AboutValue.AboutStatus = true;
            }

            abm.AboutUpdate(AboutValue);
            return RedirectToAction("Index");

        }
        
    }
}