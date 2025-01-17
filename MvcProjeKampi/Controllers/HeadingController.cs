﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManger hm = new HeadingManger(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManeger wm = new WriterManeger(new EfWriterDal());
        public ActionResult Index()
        {
            var headinvalues = hm.GetList();
            return View(headinvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value=x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategory;


            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName +" "+ x.WriterSurname,
                                                      Value = x.WriterID.ToString()

                                                  }).ToList();
            ViewBag.writer = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading( Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
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
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetByID(id);
            headingvalue.HeadinStatus = false;
            hm.HeadingDelete(headingvalue);

            return RedirectToAction("Index");
        }
    }
}