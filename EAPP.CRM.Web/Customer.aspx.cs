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
    public partial class Customer : BasePage
    {
        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
        protected EAPP.CRM.BLL.CustomerType customerTypeBLL = new EAPP.CRM.BLL.CustomerType();
        protected EAPP.CRM.BLL.Trade tradeBLL = new EAPP.CRM.BLL.Trade();
        protected EAPP.CRM.BLL.CustomerState customerStateBLL = new EAPP.CRM.BLL.CustomerState();
        protected EAPP.CRM.BLL.CustomerSource customerSourceBLL = new EAPP.CRM.BLL.CustomerSource();
        protected EAPP.CRM.BLL.Contacts contactBLL = new EAPP.CRM.BLL.Contacts();
        protected EAPP.CRM.BLL.FollowUpPlan followUpPlanBll = new EAPP.CRM.BLL.FollowUpPlan();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        protected override void SetContorlVisable()
        {
            this.btnCopy.Visible = this.HasPopedom("CustomerEdit");
            this.btnEdit.Visible = this.HasPopedom("CustomerEdit");
            this.btnPrint.Visible = false;// this.HasPopedom("CustomerAdd");
            this.btnRecycle.Visible = this.HasPopedom("CustomerDrop");
            this.btnShare.Visible = this.HasPopedom("CustomerEdit");
            this.btnAssign.Visible = this.HasPopedom("CustomerAssign");
            this.btnSearchCustomer.Visible = this.HasPopedom("CustomerAdd");
        }

        /// <summary>
        /// 绑定页面数据
        /// </summary>
        private void BindData()
        {
            this.MultiView1.ActiveViewIndex = 1;

            string customerId = Request.QueryString["cid"];

            if (string.IsNullOrEmpty(customerId))
            {
                this.lblMessage.Text = "参数错误";
            }

            Model.CustomerInfo info = this.customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(customerId));

            if (info != null)
            {
                this.MultiView1.ActiveViewIndex = 0;

                this.txtAddress.Text = info.Address;
                this.txtArea.CityId = info.AreaId.ToString();
                this.txtEmail.Text = info.Email;
                this.txtEmployeeTotal.Text = info.EmployeeTotal.ToString();
                this.txtFax.Text = info.Fax;
                this.txtHomePage.Text = info.HomePage;
                this.txtMobilePhone.Text = info.MobilePhone;
                this.txtName.Text = info.Name;
                this.txtPostCode.Text = info.PostCode;
                this.txtRemark.Text = info.Remark;

                Model.CustomerSourceInfo sourceinfo = customerSourceBLL.GetItem(info.SourceId);
                if (sourceinfo != null)
                {
                    this.txtSource.Text = sourceinfo.Source;
                }

                Model.CustomerStateInfo stateinfo = customerStateBLL.GetItem(info.StateId);
                if (stateinfo != null)
                {
                    this.txtState.Text = stateinfo.Name;
                }

                this.txtTel.Text = info.Tel;

                Model.TradeInfo trade = tradeBLL.GetItem(info.TradeId);
                if (trade != null)
                {
                    this.txtTrade.Text = trade.TradeName;
                }

                Model.CustomerTypeInfo type = customerTypeBLL.GetItem(info.TypeId);
                if (type != null)
                {
                    this.txtType.Text = type.TypeName;
                }

                this.txtYearRevenue.Text = info.YearRevenue;

                BindContactsData(customerId);
                BindFollowUpPlanData(customerId);
            }
            else
            {
                this.lblMessage.Text = "参数错误";
            }
        }

        /// <summary>
        /// 绑定客户联系人
        /// </summary>
        /// <param name="customerId">客户编号</param>
        private void BindContactsData(string customerId)
        {
            this.gvContacts.DataSource = this.contactBLL.GetList("CustomerId = " + customerId);
            this.gvContacts.DataBind();
        }

        /// <summary>
        /// 绑定客户跟进计划
        /// </summary>
        /// <param name="customerId">客户编号</param>
        private void BindFollowUpPlanData(string customerId)
        {
            this.gvFollowUpPlan.DataSource = this.followUpPlanBll.GetList("CustomerId = " + customerId);
            this.gvFollowUpPlan.DataBind();
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCustomer.aspx?cid=" + Request.QueryString["cid"]);
        }

        /// <summary>
        /// 客户通
        /// </summary>
        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            Model.CustomerInfo info = customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["cid"]));
            if (info != null) 
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("http://www.google.cn/search?hl=zh-CN&source=hp&q=");
                sb.Append(Server.HtmlEncode(info.Name));
                sb.Append("&aq=f&oq=");
                Response.Redirect(sb.ToString());
            }
        }

        /// <summary>
        /// 共享客户
        /// </summary>
        protected void btnShare_Click(object sender, EventArgs e)
        {
            Model.CustomerInfo info = customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["cid"]));
            if (info != null) 
            {
                info.IsShare = true;
                info.AssignDate = "";
                info.AssignObject = "";
                info.AssignObjectId = 0;
            }
            customerBLL.Update(info);
            Response.Redirect("AddCustomer.aspx?cid=" + Request.QueryString["cid"]);
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        protected void btnRecycle_Click(object sender, EventArgs e)
        {
            Model.CustomerInfo info = customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["cid"]));
            if (info != null) 
            {
                info.Deleted = true;                
            }
            customerBLL.Update(info);
            Response.Redirect("AddCustomer.aspx?cid=" + Request.QueryString["cid"]);
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (sender as LinkButton);
            if (btn != null) 
            {
                string conId = btn.CommandArgument;
                int k = contactBLL.Delete(conId);
                if (k > 0) 
                {
                    DataBind();
                }
            }
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx?cid=" + Request.QueryString["cid"]);
        }

        protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvw = (GridView)sender;
            gvw.PageIndex = e.NewPageIndex;
            BindContactsData(Request.QueryString["cid"]);
        }

        protected void gvFollowUpPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvw = (GridView)sender;
            gvw.PageIndex = e.NewPageIndex;
            BindFollowUpPlanData(Request.QueryString["cid"]);
        }

        protected string GetCustomerState(string stateId) 
        {
            Model.CustomerStateInfo info = customerStateBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(stateId));
            return info == null ? "<未知>" : info.Name;
        }

        protected string GetContactsName(string Id) 
        {
            Model.ContactsInfo info = this.contactBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(Id));

            return info == null ? "<未知>" : info.CnName;
        }

        protected string GetState(string state) 
        {
            state = state.ToLower();
            string res = "<未知>";
            switch (state)
            {
                case "planning":
                    res = "计划中";
                    break;
                case "processing":
                    res = "进行中";
                    break;
                case "end":
                    res = "已结束";
                    break;
            }
            return res;
        }
    }
}