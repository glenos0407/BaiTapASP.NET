using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai3_SendMail.Models
{
    public class MailInfo
    {
        public string sender { get; set; }
        public string reciever { get; set; }

        public string subject { get; set; }

        public string pwd { get; set; }

        public string content { get; set; }
    }
}