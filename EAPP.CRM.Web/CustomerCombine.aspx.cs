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
    public partial class CustomerCombine : BasePage
    {
        #region Declare

        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
        protected EAPP.CRM.BLL.CustomerSource customerSourceBLL = new EAPP.CRM.BLL.CustomerSource();
        protected EAPP.CRM.BLL.CustomerState customerStateBLL = new EAPP.CRM.BLL.CustomerState();
        protected EAPP.CRM.BLL.CustomerType customerTypeBLL = new EAPP.CRM.BLL.CustomerType();
        protected EAPP.CRM.BLL.Trade tradeBLL = new EAPP.CRM.BLL.Trade();
        protected EAPP.CRM.BLL.Dept deptBLL = new EAPP.CRM.BLL.Dept();
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
        protected EAPP.CRM.BLL.Area areaBLL = new EAPP.CRM.BLL.Area();

        #endregion

        #region BindData

        private void BindData()
        {
            this.MultiView1.ActiveViewIndex = 1;
            string fid = Request.QueryString["fid"];
            string sid = Request.QueryString["sid"];

            if (string.IsNullOrEmpty(fid) || string.IsNullOrEmpty(sid))
            {
                this.lblMessage.Text = "缺少必要参数。";
            }
            else 
            {
                int first = EAPP.CRM.Common.MyConvert.GetInt32(fid);
                int second = EAPP.CRM.Common.MyConvert.GetInt32(sid);

                Model.CustomerInfo fc = customerBLL.GetItem(first);
                Model.CustomerInfo sc = customerBLL.GetItem(second);

                if (fc == null || sc == null)
                {
                    lblMessage.Text = "数据库中不存在该客户,或者客户已被删除.";
                }
                else 
                {
                    BindFirstCustomer(fc);
                    BindSecondCustomer(sc);
                    BindCustomerSourceData();
                    BindCustomerStateData();
                    BindCustomerTypeData();
                    BindTradeData();
                    InitData(fc);
                    this.MultiView1.ActiveViewIndex = 0;
                }
            }
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
        /// 
        /// </summary>        
        private void InitData(EAPP.CRM.Model.CustomerInfo fc)
        {
            this.txtAddress.Text = fc.Address;
            //this.txtArea.CityId = fc.AreaId.ToString();
            this.txtEmail.Text = fc.Email;
            this.txtEmpTotal.Text = fc.EmployeeTotal.ToString();
            this.txtFax.Text = fc.Fax;
            this.txtHomePage.Text = fc.HomePage;
            this.txtMobile.Text = fc.MobilePhone;
            this.txtName.Text = fc.Name;
            this.txtPostCode.Text = fc.PostCode;
            this.txtRemark.Text = fc.Remark;
            this.txtTel.Text = fc.Tel;
            this.txtYear.Text = fc.YearRevenue;
            this.ddlSource.SelectedValue = fc.SourceId.ToString();
            this.ddlState.SelectedValue = fc.StateId.ToString();
            this.ddlTrade.SelectedValue = fc.TradeId.ToString();
            this.ddlType.SelectedValue = fc.TypeId.ToString();

            if ("dept".Equals(fc.AssignObject)) 
            {
                this.rbtnDept.Checked = true;
            }

            if ("user".Equals(fc.AssignObject))
            {
                this.rbtnUser.Checked = true;
            }
            
        }

        /// <summary>
        /// 绑定客户1
        /// </summary>
        private void BindFirstCustomer(Model.CustomerInfo fc)
        {
            this.lAddress1.Text = fc.Address;
            this.lArea1.Text = areaBLL.ToStringFullName(fc.AreaId);            

            if ("dept".Equals(fc.AssignObject))
            {
                Model.DeptInfo dept = deptBLL.GetItem(fc.AssignObjectId);
                this.lAssignObj1.Text = "部门" + "-" + (dept == null ? "" : dept.DeptName);
            }
            else 
            {
                Model.UserInfo user = userBLL.GetItem(fc.AssignObjectId);
                this.lAssignObj1.Text = "用户" + "-" + (user == null ? "" : user.CnName);
            }
            
            this.lEmail1.Text = fc.Email;
            this.lEmptotal1.Text = fc.EmployeeTotal;
            this.lFax1.Text = fc.Fax;
            this.lHomePage1.Text = fc.HomePage;
            this.lMobile1.Text = fc.MobilePhone;
            this.lName1.Text = fc.Name;
            this.lPostCode1.Text = fc.PostCode;
            this.lRemark1.Text = fc.Remark;
            
            this.lSource1.Text = fc.Source;

            Model.CustomerStateInfo state = customerStateBLL.GetItem(fc.StateId);
            this.lState1.Text = state == null ? "" : state.Name;

            this.lTel1.Text = fc.Tel;

            Model.TradeInfo trade = tradeBLL.GetItem(fc.TradeId);
            this.lTrade1.Text = trade == null ? "" : trade.TradeName;

            Model.CustomerTypeInfo type = customerTypeBLL.GetItem(fc.TypeId);
            this.lType1.Text = type == null ? "" : type.TypeName;

            this.lyear1.Text = fc.YearRevenue;
                        
            this.hdAddress1.Value = fc.Address;
            this.hdArea1.Value = fc.AreaId.ToString();
            this.hdAssignObject1.Value = fc.AssignObject + "," + fc.AssignObjectId;
            this.hdEmail1.Value = fc.Email;
            this.hdEmpTotal1.Value = fc.EmployeeTotal;
            this.hdFax1.Value = fc.Fax;
            this.hdHomePage1.Value = fc.HomePage;
            this.hdMobile1.Value = fc.MobilePhone;
            this.hdName1.Value = fc.Name;
            this.hdPostCode1.Value = fc.PostCode;
            this.hdRemark1.Value = fc.Remark;            
            this.hdSource1.Value = fc.SourceId == 0 ? fc.Source : fc.SourceId.ToString();
            this.hdState1.Value = fc.StateId.ToString();
            this.hdTel1.Value = fc.Tel;
            this.hdTrade1.Value = fc.TradeId.ToString();
            this.hdType1.Value = fc.TypeId.ToString();
            this.hdYear1.Value = fc.YearRevenue;
            
            this.result.Value = fc.AreaId.ToString();

        }

        /// <summary>
        /// 绑定客户2
        /// </summary>
        private void BindSecondCustomer(Model.CustomerInfo sc)
        {
            this.slAddress2.Text = sc.Address;
            this.slArea2.Text = areaBLL.ToStringFullName(sc.AreaId);

            if ("dept".Equals(sc.AssignObject))
            {
                Model.DeptInfo dept = deptBLL.GetItem(sc.AssignObjectId);
                this.slAssignObj2.Text = "部门" + "-" + (dept == null ? "" : dept.DeptName);

            }
            else
            {
                Model.UserInfo user = userBLL.GetItem(sc.AssignObjectId);
                this.slAssignObj2.Text = "用户" + "-" + (user == null ? "" : user.CnName);
            }

            this.slEmail2.Text = sc.Email;
            this.slEmptotal2.Text = sc.EmployeeTotal;
            this.slFax2.Text = sc.Fax;
            this.slHomePage2.Text = sc.HomePage;
            this.slMobile2.Text = sc.MobilePhone;
            this.slName2.Text = sc.Name;
            this.slPostCode2.Text = sc.PostCode;
            this.slRemark2.Text = sc.Remark;

            this.slSource2.Text = sc.Source;

            Model.CustomerStateInfo state = customerStateBLL.GetItem(sc.StateId);
            this.slState2.Text = state == null ? "" : state.Name;

            this.slTel2.Text = sc.Tel;

            Model.TradeInfo trade = tradeBLL.GetItem(sc.TradeId);
            this.slTrade2.Text = trade == null ? "" : trade.TradeName;

            Model.CustomerTypeInfo type = customerTypeBLL.GetItem(sc.TypeId);
            this.slType2.Text = type == null ? "" : type.TypeName;

            this.slyear2.Text = sc.YearRevenue;


            this.hdAddress2.Value = sc.Address;
            this.hdArea2.Value = sc.AreaId.ToString();
            this.hdAssignObject2.Value = sc.AssignObject + "," + sc.AssignObjectId;
            this.hdEmail2.Value = sc.Email;
            this.hdEmpTotal2.Value = sc.EmployeeTotal;
            this.hdFax2.Value = sc.Fax;
            this.hdHomePage2.Value = sc.HomePage;
            this.hdMobile2.Value = sc.MobilePhone;
            this.hdName2.Value = sc.Name;
            this.hdPostCode2.Value = sc.PostCode;
            this.hdRemark2.Value = sc.Remark;
            this.hdSource2.Value = sc.SourceId == 0 ? sc.Source : sc.SourceId.ToString();
            this.hdState2.Value = sc.StateId.ToString();
            this.hdTel2.Value = sc.Tel;
            this.hdTrade2.Value = sc.TradeId.ToString();
            this.hdType2.Value = sc.TypeId.ToString();
            this.hdYear2.Value = sc.YearRevenue;
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

        [AjaxPro.AjaxMethod]
        public DataTable GetCityData(string areaId)
        {
            return Ajax.GetAreaList(areaId);
        }

        [AjaxPro.AjaxMethod]
        public string[] GetCity(string areaId)
        {
            return Ajax.GetArea(areaId);
        }

        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(CustomerCombine));
            if (!this.IsPostBack)
            {                
                BindData();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Model.CustomerInfo info = new EAPP.CRM.Model.CustomerInfo();

            info.Address = this.txtAddress.Text;
            info.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.result.Value);
            info.AssignDate = DateTime.Now.ToString("yyyy-MM-dd");
            info.AssignObject = this.rbtnDept.Checked ? "dept" : "user";
            info.AssignObjectId = EAPP.CRM.Common.MyConvert.GetInt32(this.AssignObjectId.Value);            
            info.Deleted = false;
            info.Email = this.txtEmail.Text;
            info.EmployeeTotal = this.txtEmpTotal.Text;
            info.EnterDate = DateTime.Now;
            info.EnterUserId = (Session["UserInfo"] as EAPP.CRM.Model.UserInfo).UserId;
            info.Fax = this.txtFax.Text;
            info.HomePage = this.txtHomePage.Text;
            info.IsShare = false;            
            info.MobilePhone = this.txtMobile.Text;
            info.ModifyDate = DateTime.Now.ToString("yyyy-MM-dd");
            info.ModifyUserId = (Session["UserInfo"] as EAPP.CRM.Model.UserInfo).UserId;
            info.Name = this.txtName.Text;
            info.PostCode = this.txtPostCode.Text;
            info.Remark = this.txtRemark.Text;
            info.Source = this.txtSource.Text;
            info.SourceId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlSource.SelectedValue);
            info.StateId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlState.SelectedValue);
            info.Tel = this.txtTel.Text;
            info.TradeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlTrade.SelectedValue);
            info.TypeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlType.SelectedValue);
            info.YearRevenue = this.txtYear.Text;
            customerBLL.DropInRecycle(Request.QueryString["fid"] + "," + Request.QueryString["sid"]);
            customerBLL.Insert(info);
            Response.Redirect("CustomerList.aspx");
        }

        #endregion

        protected override string Action
        {
            get
            {
                return "CustomerCombine";
            }
        }
    }
}
