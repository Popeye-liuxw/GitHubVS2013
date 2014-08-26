using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
namespace EAPP.CRM.BLL
{
    public class SendEmail
    {
        public static bool SendMailUse163(Model.Email email)
        {
            EAPP.CRM.Config.EmailInfo info = EAPP.CRM.Config.EmailConfig.GetEmailConfig(); 

            MailMessage msg = new MailMessage();
            string[] tos = email.ToSomeBody.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tos.Length; i++)
            {
                msg.To.Add(tos[i]);
            }

            msg.From = new MailAddress(info.FixEmail, info.DisplayName, System.Text.Encoding.UTF8);

            msg.Subject = email.Subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = email.Content;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;
            msg.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(info.User, info.Pwd);
            client.Port = info.Port;
            client.Host = info.Server;
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                throw ex;
            }

            return true;
        }
    }
}
