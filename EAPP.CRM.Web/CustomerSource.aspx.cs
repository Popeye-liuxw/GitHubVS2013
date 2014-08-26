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
    public partial class CustomerSource : BasePage
    {
        protected EAPP.CRM.BLL.CustomerSource customerSourceBLL = new EAPP.CRM.BLL.CustomerSource();

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
            //this.lrpt.Visible = this.HasPopedom("GlobalAnalysis");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        private void BindData()
        {
            BindCustomerSourceData();
        }

        private void BindCustomerSourceData()
        {
            this.GridView1.DataSource = customerSourceBLL.GetList();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = (int)e.NewEditIndex;
            BindCustomerSourceData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            Model.CustomerSourceInfo info = customerSourceBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(typeId));

            GridViewRow gvRow = this.GridView1.Rows[e.RowIndex];
            info.Source = ((TextBox)gvRow.Controls[0].Controls[1]).Text;
            info.Remark = ((TextBox)gvRow.Controls[1].Controls[1]).Text;

            customerSourceBLL.Update(info);

            this.GridView1.EditIndex = -1;
            BindCustomerSourceData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            BindCustomerSourceData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            customerSourceBLL.Delete(typeId);
            BindCustomerSourceData();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Model.CustomerSourceInfo info = new EAPP.CRM.Model.CustomerSourceInfo();
            info.Source = txtName.Text.Trim();
            info.Remark = txtRemark.Text.Trim();
            customerSourceBLL.Insert(info);

            txtRemark.Text = "";
            txtName.Text = "";

            Response.Redirect("CustomerSource.aspx");
        }
    }
}
