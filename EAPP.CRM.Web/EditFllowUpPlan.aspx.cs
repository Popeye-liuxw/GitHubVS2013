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
    public partial class EditFllowUpPlan : BasePage
    {
        protected EAPP.CRM.BLL.FollowUpPlan followUpPlanBLL = new EAPP.CRM.BLL.FollowUpPlan();
        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
        protected EAPP.CRM.BLL.CustomerState customerStateBLL = new EAPP.CRM.BLL.CustomerState();
        protected EAPP.CRM.BLL.Contacts contactsBLL = new EAPP.CRM.BLL.Contacts();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            this.MultiView1.ActiveViewIndex = 1;
            string fpid = Request.QueryString["fpid"];
            if (string.IsNullOrEmpty(fpid))
            {
                this.lblMessage.Text = "缺少必要参数";
            }
            else
            {
                Model.FollowUpPlanInfo fpinfo = followUpPlanBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(fpid));                

                if (fpinfo == null)
                {
                    this.lblMessage.Text = "参数非法或该记录被移除。";
                }
                else 
                {   
                    BindStateData();
                    BindContactsData(fpinfo);

                    InitData(fpinfo);

                    this.MultiView1.ActiveViewIndex = 0;
                }
            }
        }

        private void InitData(EAPP.CRM.Model.FollowUpPlanInfo fpinfo)
        {
            Model.CustomerInfo info = customerBLL.GetItem(fpinfo.CustomerId);
            this.txtName.Text = info == null ? "" : info.Name;
            this.txtContactTime.Value = fpinfo.ContactTime.ToString("yyyy-MM-dd");
            this.txtNextTime.Value = fpinfo.NextTime;
            this.txtResult.Text = fpinfo.Result;
            this.ddlContact.SelectedValue = fpinfo.ContactId.ToString();
            this.ddlContactInfo.SelectedValue = fpinfo.ContactInfo;
            this.ddlCustomerState.SelectedValue = fpinfo.CustomerStateId.ToString();
            this.ddlState.SelectedValue = fpinfo.PlanState;
            this.txtNextTiming.Text = fpinfo.NextTiming;
            this.txtInterest.Text = fpinfo.Interest;
            this.txtDissent.Text = fpinfo.Dissent;
            
        }
        private void BindContactsData(EAPP.CRM.Model.FollowUpPlanInfo fpinfo)
        {
            this.ddlContact.DataSource = this.contactsBLL.GetList("CustomerId = " + fpinfo.CustomerId);
            this.ddlContact.DataBind();
            this.ddlContact.Items.Insert(0, new ListItem("请选择联系人…", "0"));
        }

        private void BindStateData()
        {
            this.ddlCustomerState.DataSource = this.customerStateBLL.GetList();
            this.ddlCustomerState.DataBind();

            this.ddlCustomerState.Items.Insert(0, new ListItem("请选择状态…", "0"));
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string fpid = Request.QueryString["fpid"];
            Model.FollowUpPlanInfo info = followUpPlanBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(fpid));

            info.ContactId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlContact.SelectedValue);
            info.ContactInfo = this.ddlContactInfo.SelectedValue;
            info.ContactTime = EAPP.CRM.Common.MyConvert.GetDateTime(this.txtContactTime.Value.Trim());           
            info.CustomerStateId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlCustomerState.SelectedValue);
            info.Dissent = this.txtDissent.Text;
            info.ModifyDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            info.ModifyUserId = (Session["UserInfo"] as Model.UserInfo).UserId;
            info.Interest = this.txtInterest.Text;
            info.NextTime = this.txtNextTime.Value.Trim();
            info.NextTiming = this.txtNextTiming.Text;
            info.PlanState = this.ddlState.SelectedValue;
            info.Result = this.txtResult.Text;

            followUpPlanBLL.Update(info);

            Response.Redirect("Customer.aspx?cid=" + info.CustomerId);
        }
    }
}
