using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMassagerController : Controller
    {
        // GET: WriterPanelMassager
        MessageManager MesajManger = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inbox()
        {
            var messagelist = MesajManger.GetListInbox();
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            //ViewBag.ContactCount = cm.GetList().Count;
            //ViewBag.ContactReadCount = cm.GetList().Where(x => x.ContactReadStatus == true).Count();
            //ViewBag.ContactNotReadCount = cm.GetList().Where(x => x.ContactReadStatus == false).Count();

            //ViewBag.MessageInboxCount = mm.GetListInbox().Count;
            //ViewBag.MessageReadCount = mm.GetListInbox().Where(x => x.MessageReadStatus == true).Count();
            //ViewBag.MessageNotReadCount = mm.GetListInbox().Where(x => x.MessageReadStatus == false).Count();
            //ViewBag.MessageSendboxCount = mm.GetListSendbox().Count;
            //ViewBag.MessageDraftboxCount = mm.GetListDraftbox().Count;

            return PartialView();
        }


        public ActionResult Sendbox()
        {
            var messagelist = MesajManger.GetListSendbox();
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
                p.SenderMail = "gizem@gizem.com";
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
    }
}