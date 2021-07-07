using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManger hm = new HeadingManger(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfCaontentDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}