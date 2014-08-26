using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;

namespace EAPP.CRM.Config
{
    public class EmailConfig
    {
        static XmlDocument doc = new XmlDocument();
        static EmailInfo emailInfo = new EmailInfo();
        static string path = "config/email.config";
        static string PhysicalPath = "";
        static EmailConfig()
        {
            PhysicalPath = HttpContext.Current.Server.MapPath(path);
            doc.Load(PhysicalPath);
        }

        public static EmailInfo GetEmailConfig()
        {
            emailInfo.DisplayName = doc.SelectSingleNode("/config/email/displayName/text()").Value;
            emailInfo.FixEmail = doc.SelectSingleNode("/config/email/fixEmail/text()").Value;
            emailInfo.Pwd = doc.SelectSingleNode("/config/email/smtp/pwd/text()").Value;
            emailInfo.Server = doc.SelectSingleNode("/config/email/smtp/server/text()").Value;
            emailInfo.User = doc.SelectSingleNode("/config/email/smtp/user/text()").Value;
            emailInfo.Port = EAPP.CRM.Common.MyConvert.GetInt32(doc.SelectSingleNode("/config/email/smtp/port/text()").Value);

            return emailInfo;
        }

        public static void SaveEmailConfig(EmailInfo info)
        {
            doc.SelectSingleNode("/config/email/displayName/text()").Value = info.DisplayName;
            doc.SelectSingleNode("/config/email/fixEmail/text()").Value = info.FixEmail;
            doc.SelectSingleNode("/config/email/smtp/pwd/text()").Value = info.Pwd;
            doc.SelectSingleNode("/config/email/smtp/server/text()").Value = info.Server;
            doc.SelectSingleNode("/config/email/smtp/user/text()").Value = info.User;
            doc.SelectSingleNode("/config/email/smtp/port/text()").Value = info.Port.ToString();

            doc.Save(PhysicalPath);
        }
    }


    public class EmailInfo
    {
        string fixEmail;

        public string FixEmail
        {
            get { return fixEmail; }
            set { fixEmail = value; }
        }
        string displayName;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        string server;

        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }
}