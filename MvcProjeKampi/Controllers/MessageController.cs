using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidation = new MessageValidator();
        public ActionResult Inbox()
        {
            var messagelist = cm.GetListInbox();
            return View(messagelist);
        }

        public ActionResult SendBox()
        {
            var messagelist = cm.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult GetInBoxMessageDetaList(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendBoxxMessageDetaList(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult NewMessage( Mesaj p)
        {

            ValidationResult result = messagevalidation.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                cm.MesajAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}