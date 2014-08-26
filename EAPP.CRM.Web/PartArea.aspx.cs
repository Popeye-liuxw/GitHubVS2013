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
    public partial class PartArea : BasePage
    {
        EAPP.CRM.BLL.Area areaBLL = new EAPP.CRM.BLL.Area();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                BindData();
            }
        }

        private void BindData()
        {
            string id = Request.QueryString["areaId"];
            this.GridView1.DataSource = areaBLL.GetItemByParentId(id);
            this.GridView1.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = (int)e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            Model.AreaInfo info = areaBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(typeId));

            GridViewRow gvRow = this.GridView1.Rows[e.RowIndex];
            info.AreaName = ((TextBox)gvRow.Controls[0].Controls[1]).Text;            

            areaBLL.Update(info);

            this.GridView1.EditIndex = -1;
            Response.Redirect("PartArea.aspx?areaId=" + Request.QueryString["areaId"]);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            Response.Redirect("PartArea.aspx?areaId=" + Request.QueryString["areaId"]);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string typeId = this.GridView1.DataKeys[(int)e.RowIndex].Value.ToString();
            areaBLL.Delete(typeId);
            Response.Redirect("PartArea.aspx?areaId=" + Request.QueryString["areaId"]);
        }
    }
}
