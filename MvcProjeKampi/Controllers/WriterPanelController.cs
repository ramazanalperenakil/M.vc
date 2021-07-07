using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        Context c = new Context();

        // GET: WriterPanel
        HeadingManger hm = new HeadingManger(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var headinvalues = hm.GetListByWriter(writeridinfo);
            return View(headinvalues);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string mail = (string)Session["WriterMail"];
            ViewBag.m = mail;
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();


            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.HeadinStatus = true;
            hm.HeadingAdd(p);

            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]

        public ActionResult EditHeading(Heading p)
        {
            p.HeadinStatus = true;
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetByID(id);
            headingvalue.HeadinStatus = false;
            hm.HeadingDelete(headingvalue);

            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }
    }
}