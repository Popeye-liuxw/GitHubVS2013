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
    public partial class EditCustomer : BasePage
    {
        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
        protected EAPP.CRM.BLL.Area areaBLL = new EAPP.CRM.BLL.Area();
        protected EAPP.CRM.BLL.CustomerType customerTypeBLL = new EAPP.CRM.BLL.CustomerType();
        protected EAPP.CRM.BLL.Trade tradeBLL = new EAPP.CRM.BLL.Trade();
        protected EAPP.CRM.BLL.CustomerState customerStateBLL = new EAPP.CRM.BLL.CustomerState();
        protected EAPP.CRM.BLL.CustomerSource customerSourceBLL = new EAPP.CRM.BLL.CustomerSource();
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
        protected EAPP.CRM.BLL.Dept deptBLL = new EAPP.CRM.BLL.Dept();

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(EditCustomer));
            if (!this.IsPostBack)
            {
                string customerId = Request.QueryString["cid"];
                if (string.IsNullOrEmpty(customerId))
                {
                    this.MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    EAPP.CRM.Model.CustomerInfo info = customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(customerId));
                    if (info == null)
                    {
                        this.MultiView1.ActiveViewIndex = 1;
                    }
                    else
                    {
                        this.MultiView1.ActiveViewIndex = 0;
                        BindData();
                        InitData(info);
                    }
                }
            }
        }

        #region 界面数据绑定

        /// <summary>
        /// 绑定界面数据
        /// </summary>
        void BindData()
        {
            BindCustomerTypeData();
            BindTradeData();
            BindCustomerStateData();
            BindCustomerSourceData();
        }

        /// <summary>
        /// 绑定客户类型
        /// </summary>
        void BindCustomerTypeData()
        {
            this.ddlType.DataSource = this.customerTypeBLL.GetList();
            this.ddlType.DataBind();

            this.ddlType.Items.Insert(0, new ListItem("请选择客户类型…", "0"));
        }

        /// <summary>
        /// 绑定行业
        /// </summary>
        void BindTradeData()
        {
            this.ddlTrade.DataSource = this.tradeBLL.GetList();
            this.ddlTrade.DataBind();

            this.ddlTrade.Items.Insert(0, new ListItem("请选择所属行业…", "0"));
        }

        /// <summary>
        /// 绑定客户状态
        /// </summary>
        void BindCustomerStateData()
        {
            this.ddlState.DataSource = this.customerStateBLL.GetList();
            this.ddlState.DataBind();

            this.ddlState.Items.Insert(0, new ListItem("请选择客户状态…", "0"));
        }

        /// <summary>
        /// 绑定客户来源
        /// </summary>
        void BindCustomerSourceData()
        {
            this.ddlSource.DataSource = this.customerSourceBLL.GetList();
            this.ddlSource.DataBind();

            this.ddlSource.Items.Insert(0, new ListItem("请选择客户来源…", "0"));
        }

        /// <summary>
        /// 绑定用户信息
        /// </summary>
        private void BindUserData()
        {
            //this.ddlAssignObject.DataSource = userBLL.GetList();
            //this.ddlAssignObject.DataTextField = "CnName";
            //this.ddlAssignObject.DataValueField = "UserId";
            //this.ddlAssignObject.DataBind();
        }

        /// <summary>
        /// 绑定部门信息
        /// </summary>
        private void BindDeptData()
        {
            //this.ddlAssignObject.DataSource = deptBLL.GetList();
            //this.ddlAssignObject.DataTextField = "DeptName";
            //this.ddlAssignObject.DataValueField = "DeptId";
            //this.ddlAssignObject.DataBind();
        }

        #endregion


        #region AjaxMethod
        /// <summary>
        /// 根据userOrDept的值返回用户列表或者部门列表
        /// </summary>
        /// <param name="userOrDept">只能为user或者dept</param>
        /// <returns>根据userOrDept的值返回用户列表或者部门列表</returns>
        [AjaxPro.AjaxMethod]
        public DataTable GetUserDataOrDeptData(string userOrDept)
        {
            return Ajax.GetUserDataOrDeptData(userOrDept);
        }

        #endregion

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        void InitData(Model.CustomerInfo info)
        {
            this.txtAddress.Text = info.Address;

            this.txtEmail.Text = info.Email;
            this.txtEmployeeTotal.Text = info.EmployeeTotal;
            this.txtFax.Text = info.Fax;
            this.txtHomePage.Text = info.HomePage;
            this.txtMobilePhone.Text = info.MobilePhone;
            this.txtName.Text = info.Name;
            this.txtPostCode.Text = info.PostCode;
            this.txtRemark.Text = info.Remark;
            this.txtTel.Text = info.Tel;
            this.txtYearRevenue.Text = info.YearRevenue;
            this.txtSource.Text = info.Source;
            this.Area1.CityId = info.AreaId.ToString();

            //this.date.Value = info.AssignDate; 

            //if (info.AssignObject == "user") 
            //{
            //    rbtnUser.Checked = true;
            //    BindUserData();
            //}

            //if (info.AssignObject == "dept")
            //{
            //    rbtnDept.Checked = true;
            //    BindDeptData();
            //}

            //this.ddlAssignObject.Value = info.AssignObjectId.ToString();
            this.ddlSource.SelectedValue = info.SourceId.ToString();
            this.ddlState.SelectedValue = info.StateId.ToString();
            this.ddlTrade.SelectedValue = info.TradeId.ToString();
            this.ddlType.SelectedValue = info.TypeId.ToString();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Model.CustomerInfo info = customerBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["cid"]));
            info.Address = this.txtAddress.Text.Trim();
            info.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.Area1.CityId);
            info.AssignDate = DateTime.Now.ToString("yyyy-MM-dd");
            //if (this.rbtnDept.Checked)
            //{
            //    info.AssignObject = "dept";
            //}
            //else
            //{
            info.AssignObject = "user";
            //}
            info.AssignObjectId = (Session["UserInfo"] as Model.UserInfo).UserId;

            info.Email = this.txtEmail.Text.Trim();
            info.EmployeeTotal = this.txtEmployeeTotal.Text.Trim();
            info.ModifyDate = DateTime.Now.ToString("yyyy-MM-dd");
            info.ModifyUserId = (Session["UserInfo"] as EAPP.CRM.Model.UserInfo).UserId;
            info.Fax = this.txtFax.Text.Trim();
            info.HomePage = this.txtHomePage.Text.Trim();
            info.MobilePhone = this.txtMobilePhone.Text.Trim();
            info.Name = this.txtName.Text.Trim();
            info.PostCode = this.txtPostCode.Text.Trim();
            info.Remark = this.txtRemark.Text.Trim();
            info.Source = this.ddlSource.Text;
            info.SourceId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlSource.SelectedValue);
            info.StateId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlState.SelectedValue);
            info.Tel = this.txtTel.Text.Trim();
            info.TradeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlTrade.SelectedValue);
            info.TypeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlType.SelectedValue);
            info.YearRevenue = this.txtYearRevenue.Text.Trim();
            info.Source = this.txtSource.Text;
            customerBLL.Update(info);

            Response.Redirect("CustomerList.aspx");
        }
    }
}