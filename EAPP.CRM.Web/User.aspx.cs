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
    public partial class User : BasePage
    {
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                BindData();
            }
        }

        /// <summary>
        /// 设置控件可见性
        /// </summary>
        protected override void SetContorlVisable()
        {
            //设置操作列是否显示
            if (!this.HasPopedom("UserEdit") && !this.HasPopedom("UserDelete"))
            {
                GridView1.Columns[8].Visible = false;
            }

            this.basedata.Visible = this.HasPopedom("BaseDataManage");

            this.lchangepass.Visible = true;
            this.lrole.Visible = this.HasPopedom("Role");
            //this.lrpt.Visible = this.HasPopedom("GlobalAnalysis");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        /// <summary>
        /// 当前页面的操作
        /// </summary>
        protected override string Action
        {
            get
            {
                return "UserView";
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            this.GridView1.DataSource = userBLL.GetList();
            this.GridView1.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            userBLL.Delete(userId);
            Response.Redirect("User.aspx");
        }
    }
}
