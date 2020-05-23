using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai5_SendEmailWithAttach.Models
{
    public class MailInformation
    {
        public string sender { get; set; }
        public string reciever { get; set; }

        public string pwd { get; set; }

        public string subject { get; set; }

        public string notes { get; set; }
    }
}