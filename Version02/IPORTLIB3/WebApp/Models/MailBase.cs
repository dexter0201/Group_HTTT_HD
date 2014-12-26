using System.Web;
using System.Net.Mail;
using System.Text;
using BLL;

namespace WebApp.Models
{
    public class MailBase
    {
        public bool Send(Mail mail, HttpPostedFileBase file)
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
                        System.Net.Mail.Attachment at = new System.Net.Mail.Attachment(file.InputStream, file.FileName);
                        msg.Attachments.Add(at);
                    }
                    smtp.Send(msg);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}