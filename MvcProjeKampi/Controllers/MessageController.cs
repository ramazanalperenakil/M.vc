using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager MesajManger = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // GET: Mesaj
        //[Authorize]
        public ActionResult Inbox()
        {
            var messagelist = MesajManger.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = MesajManger.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult Draftbox()
        {
            var messagelist = MesajManger.GetListDraftbox();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {

            var values = MesajManger.GetByID(id);
            if (values.MessageReadStatus == false)
            {
                values.MessageReadStatus = true;
                MesajManger.MesajUpdate(values);
            }


            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = MesajManger.GetByID(id);
            return View(values);
        }
        public ActionResult GetDraftboxMessageDetails(int id)
        {
            var values = MesajManger.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Mesaj p, string btn)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "admin@bilgisayartech.tk";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                if (btn == "Send")
                {
                    p.MessageDraftsStatus = false;
                    MesajManger.MesajAdd(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    p.MessageDraftsStatus = true;
                    MesajManger.MesajAdd(p);
                    return RedirectToAction("Draftbox");
                }

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DraftMessage(Mesaj p, string btn)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "admin@bilgisayartech.tk";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                if (btn == "Send")
                {
                    p.MessageDraftsStatus = false;
                    MesajManger.MesajUpdate(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    p.MessageDraftsStatus = true;
                    MesajManger.MesajUpdate(p);
                    return RedirectToAction("Draftbox");
                }

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public string StripHTML(string input = null)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}