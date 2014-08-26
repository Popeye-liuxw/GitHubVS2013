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
    public partial class AddUser : BasePage
    {
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
        protected EAPP.CRM.BLL.Dept deptBLL = new EAPP.CRM.BLL.Dept();
        protected EAPP.CRM.BLL.Role roleBLL = new EAPP.CRM.BLL.Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AddUser));  

            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        protected override void SetContorlVisable()
        {
            this.basedata.Visible = this.HasPopedom("BaseDataManage");

            this.lchangepass.Visible = true;
            this.lrole.Visible = this.HasPopedom("Role");
            ////this.lrpt.Visible = this.HasPopedom("GlobalAnalysis");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        protected override string Action
        {
            get
            {
                return "UserAdd";
            }
        }
        
        [AjaxPro.AjaxMethod]
        public string CheckLoginName(string userName) 
        {
            return Ajax.CheckLoginName(userName);
        }


        private void BindData()
        {
            BindDeptData();
            BindRoleData();
        }

        private void BindRoleData()
        {
            this.ddlRole.DataSource = roleBLL.GetList();
            this.ddlRole.DataBind();
            this.ddlRole.Items.Insert(0, new ListItem("请选择角色…", "0"));
        }

        private void BindDeptData()
        {
            this.ddlDept.DataSource = deptBLL.GetList();
            this.ddlDept.DataBind();
            this.ddlDept.Items.Insert(0, new ListItem("请选择部门…", "0"));
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string loginName = this.txtLoginName.Text;
            Model.UserInfo info = new EAPP.CRM.Model.UserInfo();
            info.Address = this.txtAddress.Text;
            info.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.Area1.CityId);
            info.CnName = this.txtCnName.Text;
            info.DeptId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlDept.SelectedValue);
            info.Email1 = this.txtEmail1.Text;
            info.Email2 = this.txtEmail2.Text;
            info.EnName = this.txtEnName.Text;
            info.EnterDate = DateTime.Now;
            info.EnterUserId = (Session["UserInfo"] as Model.UserInfo).UserId;
            info.Fax = this.txtFax.Text;
            info.HomePhone = this.txtHomePhone.Text;
            info.IdCard = this.txtIcCard.Text;
            info.IM = this.txtIm.Text;
            info.LoginName = loginName;
            info.MobilePhone = this.txtMobilePhone.Text;
            info.Password = EAPP.CRM.Common.SecurityUtil.MD5("000000");
            info.Post = this.txtPost.Text;
            info.Remark = this.txtRemark.Text;
            info.Status = 1;
            info.WorkPhone = this.txtWorkPhone.Text;
            info.RoleId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlRole.SelectedValue);

            userBLL.Insert(info);

            Response.Redirect("User.aspx");
        }
    }
}
