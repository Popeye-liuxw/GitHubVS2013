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
    public partial class EditContacts : BasePage
    {
        protected EAPP.CRM.BLL.Contacts contactsBLL = new EAPP.CRM.BLL.Contacts();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                string contactid = Request.QueryString["contactid"];
                if (!string.IsNullOrEmpty(contactid))
                {
                    Model.ContactsInfo info = contactsBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(contactid));
                    if (info != null)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        InitData(info);
                    }
                    else 
                    {
                        this.lblMessage.Text = "不存在该联系人";
                        MultiView1.ActiveViewIndex = 1;
                    }
                }
                else 
                {
                    this.lblMessage.Text = "缺少必要参数";
                    MultiView1.ActiveViewIndex = 1;
                }
            }
        }

        void InitData(EAPP.CRM.Model.ContactsInfo info)
        {
            this.txtCnName.Text = info.CnName;
            this.txtContactAddress.Text = info.Address;
            this.txtContactEmail1.Text = info.Email1;
            this.txtContactEmail2.Text = info.Email2;
            this.txtContactFax.Text = info.Fax;
            this.txtContactMobilePhone.Text = info.MobilePhone;
            this.txtContactRemark.Text = info.Remark;
            this.txtContactTel.Text = info.Tel;
            this.txtEnName.Text = info.EnName;
            this.txtIm.Text = info.IM;
            this.txtNickName.Text = info.NickName;
            this.txtPost.Text = info.Post;
            this.txtSalutation.Text = info.Salutation;
            this.rbtnMain.Checked = info.IsMainContact;
            if ("female".Equals(info.Sex))
            {
                this.rbtnFemale.Checked = true;
            }
            else 
            {
                this.rbtnMale.Checked = true;
            }
            this.Area1.CityId = info.AreaId.ToString();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Model.ContactsInfo info = this.contactsBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["contactid"]));
            if (info != null) 
            {
                info.Address = this.txtContactAddress.Text;
                info.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.Area1.CityId);
                info.CnName = this.txtCnName.Text;                
                info.Email1 = this.txtContactEmail1.Text;
                info.Email2 = this.txtContactEmail2.Text;
                info.EnName = this.txtEnName.Text;
                info.ModifyDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                info.ModifyUserId = (Session["UserInfo"] as EAPP.CRM.Model.UserInfo).UserId;
                info.Fax = this.txtContactFax.Text;
                info.IM = this.txtIm.Text;
                info.IsMainContact = this.rbtnMain.Checked;
                info.MobilePhone = this.txtContactMobilePhone.Text;
                info.NickName = this.txtNickName.Text;
                info.Post = this.txtPost.Text;
                info.Remark = this.txtContactRemark.Text;
                info.Salutation = this.txtSalutation.Text;
                if (rbtnMale.Checked)
                {
                    info.Sex = "male";
                }
                else
                {
                    info.Sex = "female";
                }
                info.Tel = this.txtContactTel.Text;

                int k = contactsBLL.Update(info);
                if (k > 0) 
                {
                    Response.Redirect("Customer.aspx?cid=" + info.CustomerId);
                }
            }
        }
    }
}
