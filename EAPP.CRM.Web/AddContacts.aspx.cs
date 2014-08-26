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
    public partial class AddContacts : BasePage
    {
        protected EAPP.CRM.BLL.Contacts contactsBLL = new EAPP.CRM.BLL.Contacts();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Model.ContactsInfo cinfo = new EAPP.CRM.Model.ContactsInfo();

            cinfo.Address = this.txtContactAddress.Text;
            cinfo.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.Area1.CityId);
            cinfo.CnName = this.txtCnName.Text;
            cinfo.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["cid"]);
            cinfo.Email1 = this.txtContactEmail1.Text;
            cinfo.Email2 = this.txtContactEmail2.Text;
            cinfo.EnName = this.txtEnName.Text;
            cinfo.EnterDate = DateTime.Now;
            cinfo.EnterUserId = (Session["UserInfo"] as EAPP.CRM.Model.UserInfo).UserId;
            cinfo.Fax = this.txtContactFax.Text;
            cinfo.IM = this.txtIm.Text;
            cinfo.IsMainContact = this.rbtnMain.Checked;
            cinfo.MobilePhone = this.txtContactMobilePhone.Text;
            cinfo.NickName = this.txtNickName.Text;
            cinfo.Post = this.txtPost.Text;
            cinfo.Remark = this.txtContactRemark.Text;
            cinfo.Salutation = this.txtSalutation.Text;
            if (rbtnMale.Checked)
            {
                cinfo.Sex = "male";
            }
            else
            {
                cinfo.Sex = "female";
            }
            cinfo.Tel = this.txtContactTel.Text;
            contactsBLL.Insert(cinfo);
            Response.Redirect("Customer.aspx?cid=" + Request.QueryString["cid"]);
        }
    }
}
