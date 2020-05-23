using Bai3_SendMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Bai3_SendMail.Controllers
{
    public class MailController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frmCollection)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(frmCollection["txtSender"]);
                    mail.To.Add(frmCollection["txtReceiver"]);
                    mail.Subject = frmCollection["txtSubject"];
                    mail.Body = frmCollection["txtContent"];
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(frmCollection["txtSender"], frmCollection["pwd"]);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }
            }
            catch
            {
                ViewBag.Message = "FAILED: YOUR MAIL ISN'T SENT !";
                return View();
            }

            ViewBag.Message = "YOUR MAIL HAS BEEN SENT !";
            return View();
        }
    }
}