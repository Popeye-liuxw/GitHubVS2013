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
    public partial class EditUser : BasePage
    {
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
        protected EAPP.CRM.BLL.Dept deptBLL = new EAPP.CRM.BLL.Dept();
        protected EAPP.CRM.BLL.Role roleBLL = new EAPP.CRM.BLL.Role();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        #region Override

        protected override string Action
        {
            get 
            {
                return "UserEdit";
            }
        }

        protected override void ValidatePopedom()
        {
            string uid = Request.QueryString["uid"];
            if (!string.IsNullOrEmpty(uid))
            {
                base.ValidatePopedom();

                Model.UserInfo sinfo = Session["UserInfo"] as Model.UserInfo;

                Model.UserInfo info = userBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(uid));

                if (info == null) return;

                if (sinfo.LoginName.ToLower() != "admin")
                {
                    if (info.LoginName.ToLower() == "admin")
                    {
                        Response.Write(@"<script>alert('非法操作');document.location.href='Main.aspx'</script>");
                        Response.End();
                    }
                }
            }
        }

        protected override void SetContorlVisable()
        {
            this.basedata.Visible = this.HasPopedom("BaseDataManage");

            this.lchangepass.Visible = true;
            this.lrole.Visible = this.HasPopedom("Role");
            //this.lrpt.Visible = this.HasPopedom("GlobalAnalysis");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        #endregion

        private void BindData()
        {
            BindDeptData();
            BindRoleData();

            InitData();
        }

        private void BindRoleData()
        {
            this.ddlRole.DataSource = roleBLL.GetList();
            this.ddlRole.DataBind();
            this.ddlRole.Items.Insert(0, new ListItem("请选择角色…", "0"));
        }

        private void InitData()
        {
            Model.UserInfo info = null;

            this.MultiView1.ActiveViewIndex = 1;

            string uid = Request.QueryString["uid"];

            if (string.IsNullOrEmpty(uid))
            {
                info = Session["UserInfo"] as Model.UserInfo;
            }
            else
            {
                info = userBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(uid));
            }

            if (info == null)
            {
                lblMessage.Text = "该用户可能已经被删除。";
            }
            else 
            {
                this.MultiView1.ActiveViewIndex = 0;

                this.txtAddress.Text = info.Address;
                this.txtCnName.Text = info.CnName;
                this.txtEmail1.Text = info.Email1;
                this.txtEmail2.Text = info.Email2;
                this.txtEnName.Text = info.EnName;
                
                this.txtFax.Text = info.Fax;
                this.txtHomePhone.Text = info.HomePhone;
                this.txtIcCard.Text = info.IdCard;
                this.txtIm.Text = info.IM;
                this.txtLoginName.Text = info.LoginName;
                this.txtMobilePhone.Text = info.MobilePhone;
                this.txtPost.Text = info.Post;
                this.txtRemark.Text = info.Remark;
                this.txtWorkPhone.Text = info.WorkPhone;
                this.Area1.CityId = info.AreaId.ToString();
                this.ddlRole.SelectedValue = info.RoleId.ToString();
                this.ddlDept.SelectedValue = info.DeptId.ToString();
            }
        }

        private void BindDeptData()
        {
            this.ddlDept.DataSource = deptBLL.GetList();
            this.ddlDept.DataBind();
            this.ddlDept.Items.Insert(0, new ListItem("请选择部门…", "0"));
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string uid = Request.QueryString["uid"];

            Model.UserInfo info = null;
            if (string.IsNullOrEmpty(uid))
            {
                info = Session["UserInfo"] as Model.UserInfo;
            }
            else
            {
                info = userBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(uid));
            }

            info.Address = this.txtAddress.Text;
            info.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.Area1.CityId);
            info.CnName = this.txtCnName.Text;
            info.DeptId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlDept.SelectedValue);
            info.Email1 = this.txtEmail1.Text;
            info.Email2 = this.txtEmail2.Text;
            info.EnName = this.txtEnName.Text;
            info.ModifyDate = DateTime.Now.ToString("yyyy-MM-dd");
            info.ModifyUserId = (Session["UserInfo"] as Model.UserInfo).UserId;
            info.Fax = this.txtFax.Text;
            info.HomePhone = this.txtHomePhone.Text;
            info.IdCard = this.txtIcCard.Text;
            info.IM = this.txtIm.Text;            
            info.LoginName = this.txtLoginName.Text;
            info.MobilePhone = this.txtMobilePhone.Text;            
            info.Post = this.txtPost.Text;
            info.Remark = this.txtRemark.Text;
            info.Status = 1;
            info.WorkPhone = this.txtWorkPhone.Text;
            info.RoleId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlRole.SelectedValue);
            string pwd = this.txtPwd.Text.Trim();
            if (!string.IsNullOrEmpty(pwd))
            {
                info.Password = EAPP.CRM.Common.SecurityUtil.MD5(pwd);
            }

            userBLL.Update(info);

            Response.Redirect("User.aspx");
        }
    }
}
