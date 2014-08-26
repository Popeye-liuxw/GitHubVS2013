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
    public partial class SearchContact : BasePage
    {
        #region Members

        protected EAPP.CRM.BLL.CustomerState customerStateBLL = new EAPP.CRM.BLL.CustomerState();
        protected EAPP.CRM.BLL.Trade tradeBLL = new EAPP.CRM.BLL.Trade();
        protected EAPP.CRM.BLL.Contacts contactsBLL = new EAPP.CRM.BLL.Contacts();

        #endregion 

        #region 数据绑定

        /// <summary>
        /// 数据绑定
        /// </summary>
        void BindData() 
        {
            BindStateData();
            BindTradeState();
            BindContactsData();
        }

        /// <summary>
        /// 绑定客户状态
        /// </summary>
        void BindStateData() 
        {
            this.ddlState.DataSource = this.customerStateBLL.GetList();
            this.ddlState.DataBind();

            this.ddlState.Items.Insert(0, new ListItem("请选择客户状态…", "0"));
        }

        /// <summary>
        /// 绑定行业
        /// </summary>
        void BindTradeState() 
        {
            this.ddlTrade.DataSource = this.tradeBLL.GetList();
            this.ddlTrade.DataBind();

            this.ddlTrade.Items.Insert(0, new ListItem("请选择主营行业…", "0"));
        }

        /// <summary>
        /// 绑定联系人
        /// </summary>
        void BindContactsData() 
        {
            Model.SearchContactsParameter parm = new EAPP.CRM.Model.SearchContactsParameter();

            DataTable table = new DataTable();
            string name = Request.QueryString["key"];
            if (!string.IsNullOrEmpty(name))
            {   
                parm.ContactName = name;
                parm.CurUserId = (Session["UserInfo"] as Model.UserInfo).UserId;
                this.txtContactName.Text = name;
            }
            table = contactsBLL.Search(parm);
            this.gvlist.DataSource = table;
            this.gvlist.DataBind();
        }

        #endregion 

        #region Event

        /// <summary>
        /// OnLoad 事件
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 联系人高级查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSearchData();
        }

        void BindSearchData()
        {
            Model.SearchContactsParameter parm = new EAPP.CRM.Model.SearchContactsParameter();
            parm.ContactName = this.txtContactName.Text.Trim();
            parm.CustomerName = this.txtCustomerName.Text.Trim();
            parm.Email = this.txtEmail.Text.Trim();
            parm.Fields = "*";
            parm.OtherWhere = "";
            parm.StateId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlState.SelectedValue);
            parm.Tel = this.txtTel.Text.Trim();
            parm.TradeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlTrade.SelectedValue);
            parm.CurUserId = (Session["UserInfo"] as Model.UserInfo).UserId;

            this.gvlist.DataSource = contactsBLL.Search(parm);
            this.gvlist.DataBind();
        }

        #endregion

        protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvw = (GridView)sender;
            gvw.PageIndex = e.NewPageIndex;
            BindSearchData();
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
                int k = contactsBLL.Delete(conId);
                if (k > 0)
                {
                    BindData();
                }
            }
        }
    }
}
