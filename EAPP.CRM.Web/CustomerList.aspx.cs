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
using System.IO;

namespace EAPP.CRM.Web
{
    public partial class CustomerList : BasePage
    {
        protected EAPP.CRM.BLL.CustomerType customerTypeBLL = new EAPP.CRM.BLL.CustomerType();
        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
        protected EAPP.CRM.BLL.Trade tradeBLL = new EAPP.CRM.BLL.Trade();
        protected EAPP.CRM.BLL.CustomerState customerStateBLL = new EAPP.CRM.BLL.CustomerState();
        protected EAPP.CRM.BLL.Contacts contactsBLL = new EAPP.CRM.BLL.Contacts();
        protected EAPP.CRM.BLL.CustomerSource customerSourceBLL = new EAPP.CRM.BLL.CustomerSource();

        int type = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                type = EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]);
                
                BindData(type);
            }
        }

        protected override void SetContorlVisable()
        {
            this.btnAdd.Visible = this.HasPopedom("CustomerAdd");
            this.btnAdd2.Visible = this.HasPopedom("CustomerAdd");
            this.btnAssign.Visible = this.HasPopedom("CustomerAssign");
            this.btnAssign2.Visible = this.HasPopedom("CustomerAssign");
            this.btnAssign3.Visible = this.HasPopedom("CustomerAssign");
            this.btnBack4.Visible = this.HasPopedom("CustomerDrop");
            this.btnCombine.Visible = this.HasPopedom("CustomerCombine");
            this.btnDelete4.Visible = this.HasPopedom("CustomerDelete");
            this.btnDelete2.Visible = this.HasPopedom("CustomerDelete");
            this.btnExport.Visible = this.HasPopedom("CustomerExport");
            this.btnImport.Visible = false; //this.HasPopedom("CustomerImport");
            this.btnRecycle.Visible = this.HasPopedom("CustomerDrop");
            this.btnRecycle2.Visible = this.HasPopedom("CustomerDrop");
            this.btnRecycle3.Visible = this.HasPopedom("CustomerDrop");
            this.plSearch.Visible = this.HasPopedom("CustomerSearch");
            this.btnShare.Visible = this.HasPopedom("CustomerShare");
            this.btnShare3.Visible = this.HasPopedom("CustomerShare");
        }

        void BindData(int type)
        {
            DataTable table = new DataTable();
            EAPP.CRM.Model.UserInfo info = Session["UserInfo"] as EAPP.CRM.Model.UserInfo;

            switch (type)
            {
                case 1:
                    table = this.customerBLL.GetList("IsShare = 1 and Deleted = 0");
                    break;
                case 2:
                    Model.UserInfo uInfo = Session["UserInfo"] as Model.UserInfo;

                    Model.SearchCustomerParameter param = new EAPP.CRM.Model.SearchCustomerParameter();
                    string name = Request.QueryString["key"];
                    param.CustomerName = name;
                    this.txtName.Text = name;
                    param.CurUserId = uInfo.UserId;
                    
                    table = customerBLL.Search(param);                    
                    break;
                case 3:
                    table = this.customerBLL.GetList("Deleted = 1");
                    break;
                default:
                    table = this.customerBLL.GetList("(AssignObjectId = " + info.UserId + " and AssignObject = 'user') and Deleted = 0 and IsShare = 0");
                    break;
            }
            this.gvlist.DataSource = table;
            this.gvlist.DataBind();

            BindCustomerStateData();
            BindCustomerTypeData();
            BindTradeData();
            BindSourceData();

            if (type != 2)
            {
                this.MultiView1.ActiveViewIndex = type;
            }
        }

        void BindSourceData() 
        {
            this.ddlSource.DataSource = customerSourceBLL.GetList();
            this.ddlSource.DataBind();

            this.ddlSource.Items.Insert(0, new ListItem("请选择客户来源…", "0"));
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
            this.ddlTrade.Items.Insert(0, new ListItem("请选择主营行业…", "0"));
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
        /// 根据客户名称，返回在谷歌查询客户的URL
        /// </summary>
        protected string SearchCustomer(string customerName)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("http://www.google.cn/search?hl=zh-CN&source=hp&q=");
            sb.Append(Server.HtmlEncode(customerName));
            sb.Append("&aq=f&oq=");
            return sb.ToString();
        }

        /// <summary>
        /// 根据客户类型编号，返回客户类型名称
        /// </summary>
        protected string GetCustomerTypeName(string id)
        {
            string res = "";

            Model.CustomerTypeInfo info = customerTypeBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(id));

            if (info != null)
            {
                res = info.TypeName;
            }
            return res;
        }

        protected string GetCustomerTradeName(string id)
        {
            string res = "";

            Model.TradeInfo info = tradeBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(id));

            if (info != null)
            {
                res = info.TradeName;
            }
            return res;
        }

        protected string GetCustomerStateName(string id)
        {
            string res = "";

            Model.CustomerStateInfo info = customerStateBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(id));

            if (info != null)
            {
                res = info.Name;
            }
            return res;
        }

        protected string GetCustomerSourceName(string id)
        {
            string res = "";

            Model.CustomerSourceInfo info = customerSourceBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(id));

            if (info != null)
            {
                res = info.Source;
            }
            return res;
        }

        /// <summary>
        /// 批量放入回收站
        /// </summary>
        protected void ibtnRemove_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((HtmlInputCheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + this.gvlist.DataKeys[GR.RowIndex].Value.ToString();
                }
            }
            if (ids.IndexOf(",") == 0)
                ids = ids.Substring(1);
            customerBLL.DropInRecycle(ids);
            BindData(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]));
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            string ids = "";
            ids = btn.CommandArgument;
            customerBLL.DropInRecycle(ids);
            BindData(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]));
        }

        /// <summary>
        /// 批量共享客户
        /// </summary>
        protected void ibtnShare_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((HtmlInputCheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + this.gvlist.DataKeys[GR.RowIndex].Value.ToString();
                }
            }
            if (ids.IndexOf(",") == 0)
                ids = ids.Substring(1);
            customerBLL.ShareCustomers(ids);
            BindData(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]));
        }

        /// <summary>
        /// 永久删除
        /// </summary>
        protected void ibtnDelete_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((HtmlInputCheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + this.gvlist.DataKeys[GR.RowIndex].Value.ToString();
                }
            }
            if (ids.IndexOf(",") == 0)
                ids = ids.Substring(1);
            customerBLL.Delete(ids);
            BindData(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]));
        }

        /// <summary>
        /// 从回收站恢复选中客户
        /// </summary>
        protected void ibtnBack_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((HtmlInputCheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + this.gvlist.DataKeys[GR.RowIndex].Value.ToString();
                }
            }
            if (ids.IndexOf(",") == 0)
                ids = ids.Substring(1);
            customerBLL.BackFromInRecycle(ids);
            BindData(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]));
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx");
        }

        /// <summary>
        /// 查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Model.UserInfo info = Session["UserInfo"] as Model.UserInfo;

            Model.SearchCustomerParameter param = new EAPP.CRM.Model.SearchCustomerParameter();
            param.AreaId = EAPP.CRM.Common.MyConvert.GetInt32(this.Area1.CityId);
            param.TypeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlType.SelectedValue);
            param.TradeId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlTrade.SelectedValue);
            param.StateId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlState.SelectedValue);
            param.Contacts = this.txtContact.Text.Trim();
            param.CustomerName = this.txtName.Text.Trim();
            param.CurUserId = info.UserId;
            param.Address = this.txtAddress.Text.Trim();
            param.SourceId = EAPP.CRM.Common.MyConvert.GetInt32(this.ddlSource.SelectedValue);
            param.Tel = this.txtTel.Text.Trim();
            param.Mobile = this.txtMobile.Text.Trim();
            param.AssignDateStart = this.AssignDateStart.Value.Trim();
            param.AssignDateEnd = this.AssignDateEnd.Value.Trim();
            param.NearTiemStart = this.NearTiemStart.Value.Trim();
            param.NearTimeEnd = this.NearTimeEnd.Value.Trim();
            param.NextTimeStart = this.NextTimeStart.Value.Trim();
            param.NextTimeEnd = this.NextTimeEnd.Value.Trim();

            this.gvlist.DataSource = customerBLL.Search(param);
            this.gvlist.DataBind();
        }

        protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gvw = (GridView)sender;
            gvw.PageIndex = e.NewPageIndex;

            BindData(EAPP.CRM.Common.MyConvert.GetInt32(Request.QueryString["type"]));
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Model.UserInfo info = Session["UserInfo"] as EAPP.CRM.Model.UserInfo;

            DataTable dt = this.customerBLL.ImportData(info.UserId);

            StringWriter sw = new StringWriter();
            GridView dv = new GridView();
            dv.DataSource = dt;
            dv.DataBind();
            dv.AllowPaging = true;
            Response.ClearContent();

            Response.AppendHeader("Content-Disposition", "attachment;filename=Customers_" + DateTime.Now.ToShortDateString().ToString() + ".xlsx");

            Response.ContentType = "application/excel";
            Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=UTF8\">");
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dv.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}