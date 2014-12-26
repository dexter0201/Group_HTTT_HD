using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Text;
using WebApp.Models;
using BLL;

namespace WebApp.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SendMail(Mail mail, HttpPostedFileBase file)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    MailMessage msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(Setting.From),
                        Subject = mail.Subject,
                        Body = mail.Message,
                        Priority = MailPriority.Normal
                    };
                    msg.To.Add(mail.To);
                    if (mail.CC != null)
                        msg.CC.Add(mail.CC);
                    if (mail.BCC != null)
                        msg.Bcc.Add(mail.BCC);
                    if (file != null && file.ContentLength > 0)
                    {
                        Attachment at = new Attachment(file.InputStream, file.FileName);
                        msg.Attachments.Add(at);
                    }
                    smtp.Send(msg);
                }
                return Json("Successfull");
            }
            catch
            {
                return Json("Error");
            }
        }
    }
}
