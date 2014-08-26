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
    public partial class CustomerTrade : BasePage
    {
        protected EAPP.CRM.BLL.Trade tradeBLL = new EAPP.CRM.BLL.Trade();

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
            BindTradeData();
        }

        private void BindTradeData()
        {
            this.GridView1.DataSource = tradeBLL.GetList();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = (int)e.NewEditIndex;
            BindTradeData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            Model.TradeInfo info = tradeBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(typeId));

            GridViewRow gvRow = this.GridView1.Rows[e.RowIndex];
            info.TradeName = ((TextBox)gvRow.Controls[0].Controls[1]).Text;
            info.FlagName = ((TextBox)gvRow.Controls[1].Controls[1]).Text;

            tradeBLL.Update(info);

            this.GridView1.EditIndex = -1;
            BindTradeData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            BindTradeData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            tradeBLL.Delete(typeId);
            BindTradeData();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Model.TradeInfo info = new EAPP.CRM.Model.TradeInfo();
            info.TradeName = txtName.Text.Trim();
            info.FlagName = txtRemark.Text.Trim();
            tradeBLL.Insert(info);

            txtRemark.Text = "";
            txtName.Text = "";

            Response.Redirect("CustomerTrade.aspx");
        }
    }
}
