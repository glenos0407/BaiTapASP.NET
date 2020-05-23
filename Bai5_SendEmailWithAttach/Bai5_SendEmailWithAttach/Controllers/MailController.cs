using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Bai5_SendEmailWithAttach.Controllers
{
    public class MailController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Bai5_SendEmailWithAttach.Models.MailInformation mailInfor, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(mailInfor.sender);
                        mail.To.Add(mailInfor.reciever);
                        mail.Subject = mailInfor.subject;
                        mail.Attachments.Add(new Attachment(fileUpload.InputStream, fileUpload.FileName));
                        mail.Body = mailInfor.notes;
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(mailInfor.sender, mailInfor.pwd);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
                catch
                {
                    ViewBag.Message = "Failed !";
                    return View();
                }

                ViewBag.Message = "Email has sent !";
            }

            return View();
        }
    }
}