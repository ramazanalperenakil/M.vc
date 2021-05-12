using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class İstatislikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            
            var TopKatSay = c.Categories.Count().ToString();
            ViewBag.TopKatSay = TopKatSay;       
            var Yazilim = c.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.Yazilim = Yazilim;
            var aharf = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.aharf = aharf; 
            var baslik = c.Categories.Where(u => u.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
               .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.baslik = baslik;
            var t = c.Categories.Count(x => x.CategoryStatus == true);
            var f = c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.tffark = (t - f);
            return View();
        }
    }
}

