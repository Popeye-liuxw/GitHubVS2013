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
    public partial class AddFllowUpPlan : BasePage
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

        protected override string Action
        {
            get
            {
                return "CustomerAdd";
            }
        }

        private void BindData()
        {
            string cid = Request.QueryString["cid"];
            if (string.IsNullOrEmpty(cid))
            {
                //错误
            }
            Model.CustomerInfo info = customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(cid));
            if (info != null)
            {
                this.txtName.Text = info.Name;
            }
            else 
            {
                //错误
            }
            BindStateData();
            BindContactsData();
        }

        private void BindContactsData()
        {
            this.ddlContact.DataSource = this.contactsBLL.GetList("CustomerId = " + Request.QueryString["cid"]);
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
            EAPP.CRM.Model.FollowUpPlanInfo info = new EAPP.CRM.Model.FollowUpPlanInfo();
            info.ContactId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlContact.SelectedValue);
            info.ContactInfo = this.ddlContactInfo.SelectedValue;
            info.ContactTime = EAPP.CRM.Common.MyConvert.GetDateTime(this.txtContactTime.Value.Trim());
            info.CustomerId = EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["cid"]);
            info.CustomerStateId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlCustomerState.SelectedValue);
            info.Dissent = this.Dissent.Text;
            info.EnterDate = DateTime.Now;
            info.EnterUserId = (Session["UserInfo"] as Model.UserInfo).UserId;
            info.Interest = this.Interest.Text;
            info.NextTime = this.txtNextTime.Value.Trim();
            info.NextTiming = this.NextTiming.Text;
            info.PlanState = this.ddlState.SelectedValue;
            info.Result = this.txtResult.Text;

            followUpPlanBLL.Insert(info);

            Response.Redirect("Customer.aspx?cid=" + Request.QueryString["cid"]);
        }
    }
}
