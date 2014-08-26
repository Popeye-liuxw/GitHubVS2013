using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace EAPP.CRM.Web
{
    public partial class SendMail : BasePage
    {
        protected EAPP.CRM.BLL.Contacts contactsBLL = new EAPP.CRM.BLL.Contacts();

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SendMail));

            if (!IsPostBack) 
            {
                this.MultiView1.ActiveViewIndex = 0;
                BindData();
            }
        }

        [AjaxPro.AjaxMethod]
        public string[] getAddress(string id, string ids)
        {
            //,1,12,
            string[] res = new string[2] { ids, "" };
            int index = (ids + ",").IndexOf("," + id + ",");
            if (index == -1) 
            {
                Model.ContactsInfo info = contactsBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(id));
                if (info != null) 
                {
                    res[1] = (string.IsNullOrEmpty(info.Email1) ? info.Email2 : info.Email1) + ";";
                    ids += "," + id;
                    res[0] = ids;
                }
            }
            return res;
        }

        private void BindData()
        {
            BindContactsData();
        }

        private void BindContactsData()
        {
            this.Repeater1.DataSource = this.contactsBLL.GetList(" CustomerId in (select CustomerId from crm_Customer where AssignObjectId = " + (Session["UserInfo"] as Model.UserInfo).UserId + " and AssignObject='user' and IsShare = 0 and Deleted = 0)");
            this.Repeater1.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Model.Email mail = new EAPP.CRM.Model.Email();
            mail.Content = this.txtContent.Text;
            mail.Subject = this.txtSubject.Text;
            mail.ToSomeBody = this.txtTo.Text;
            try
            {
                EAPP.CRM.BLL.SendEmail.SendMailUse163(mail);
                this.MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                this.MultiView1.ActiveViewIndex = 2;
                this.lblErrMessage.Text = ex.Message;
            }
        }
    }
}
