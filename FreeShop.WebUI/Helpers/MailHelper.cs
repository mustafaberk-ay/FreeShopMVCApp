using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FreeShop.WebUI.Helpers
{
    public static class MailHelper
    {
        public static void Send(string to, string title, string message)
        {
            MailMessage mailMessage = new MailMessage("bizim_mail_adresimiz", to);

            mailMessage.Subject = title;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Credentials = new NetworkCredential("bizim_mail_adresimiz", "bizim_mail_adresimizin_parolasi");
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }
    }
}
