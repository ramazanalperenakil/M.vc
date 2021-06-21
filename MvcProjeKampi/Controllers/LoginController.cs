using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        LoginManager lm = new LoginManager();
        AdminManager adm = new AdminManager(new EfAdminDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var userHash = lm.PasswordHash(p.AdminUserNAme);
            var passwordHash = lm.PasswordHash(p.MyPasword);
            var adminuserinfo = adm.GetByAdmin(userHash, passwordHash);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserNAme, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserNAme;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
                
            }

        }

    }
}