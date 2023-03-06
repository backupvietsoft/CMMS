using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Vs.Support.Commons
{
    public static class SentMail
    {
        public static string MailFrom = "skeylerhack@gmail.com";
        public static string MailPass = "01689561596";
        public static string MailSMTP = "smtp.gmail.com";
        public static int MailPort = 587;
        public static string ShortName = "WAHL";
        public static void SendMail(string MailTo,string SubJect,string Body)
        {
            var loginInfo = new NetworkCredential(MailFrom, MailPass);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient(MailSMTP, MailPort);
            smtpClient.UseDefaultCredentials = true;
            msg.From = new MailAddress(MailFrom, ShortName);
            var mail = MailTo.Split(';');
            foreach (var item in mail)
            {
                if (item.Trim() != "")
                {
                    msg.To.Add(new MailAddress(item));
                }
            }
            msg.Subject = SubJect;
            msg.Body = Body;

            //msg.Attachments.Add(new Attachment(openFileDialog1.FileName));

            msg.IsBodyHtml = true;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            //msg.Priority = MailPriority.High;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
        public static void SendMailAttac(string MailTo, string SubJect, string Body,string Attac)
        {
            string MailFrom = "skeylerhack@gmail.com";
            string MailPass = "01689561596";
            string MailSMTP = "smtp.gmail.com";
            int MailPort = 587;

            var loginInfo = new NetworkCredential(MailFrom, MailPass);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient(MailSMTP, MailPort);
            msg.From = new MailAddress(MailFrom, "ANDON -  WAHL");
            var mail = MailTo.Split(';');
            foreach (var item in mail)
            {
                if (item.Trim() != "")
                {
                    msg.To.Add(new MailAddress(item));
                }
            }
            msg.Subject = SubJect;
            msg.Body = Body;

            msg.Attachments.Add(new Attachment(Attac));

            msg.IsBodyHtml = true;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            //msg.Priority = MailPriority.High;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }

    }
}
