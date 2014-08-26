using System;
using System.Collections.Generic;
using System.Text;

namespace EAPP.CRM.Model
{
    public class Email
    {
        string toSomeBody;

        public string ToSomeBody
        {
            get { return toSomeBody; }
            set { toSomeBody = value; }
        }

        string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
