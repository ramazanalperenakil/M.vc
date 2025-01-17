﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Mesaj
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(100)]
        public string Subjet { get; set; }

        [AllowHtml]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

        public bool MessageReadStatus { get; set; }
        public bool MessageDraftsStatus { get; set; }
    }
}
