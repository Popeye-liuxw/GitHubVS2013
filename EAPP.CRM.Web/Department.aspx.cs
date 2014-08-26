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
    public partial class Department : BasePage
    {
        protected EAPP.CRM.BLL.Dept deptBLL = new EAPP.CRM.BLL.Dept();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        protected override string Action
        {
            get
            {
                return "BaseDataManage";
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

        private void BindData()
        {
            BindDeptData();
        }

        private void BindDeptData()
        {
            this.GridView1.DataSource = deptBLL.GetList();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = (int)e.NewEditIndex;
            BindDeptData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            Model.DeptInfo info = deptBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(typeId));

            GridViewRow gvRow = this.GridView1.Rows[e.RowIndex];
            info.DeptName = ((TextBox)gvRow.Controls[0].Controls[1]).Text;
            info.Remark = ((TextBox)gvRow.Controls[1].Controls[1]).Text;

            deptBLL.Update(info);

            this.GridView1.EditIndex = -1;
            BindDeptData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            BindDeptData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            deptBLL.Delete(typeId);
            BindDeptData();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Model.DeptInfo info = new EAPP.CRM.Model.DeptInfo();
            info.DeptName = txtName.Text.Trim();
            info.Remark = txtRemark.Text.Trim();
            deptBLL.Insert(info);

            txtRemark.Text = "";
            txtName.Text = "";

            Response.Redirect("Department.aspx");
        }
    }
}
