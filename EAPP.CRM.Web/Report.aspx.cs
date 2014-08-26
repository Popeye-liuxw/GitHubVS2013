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
using System.Text;

namespace EAPP.CRM.Web
{
    public partial class Report : BasePage
    {
        EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();
        EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
                string type = "";
                type = Request.QueryString["type"];
                if (string.IsNullOrEmpty(type))
                {
                    type = "1";
                }

                //ype=1">客户来源</a></li>
                //ype=2">客户状态</a></li>
                //ype=3">客户类型</a></li>
                //ype=4">行业</a></li>
                //ype=5">地区</a></li>
                //ype=5">客户发展月趋势图</a></li>

                InitData();

                string tp = "Source";

                switch (type)
                {
                    case "2":
                        tp = "State";
                        break;
                    case "3":
                        tp = "Type";
                        break;
                    case "4":
                        tp = "Trade";
                        break;
                    case "5":
                        tp = "Area";
                        break;
                    case "6":
                        tp = "Trend";
                        break;
                    default:
                        tp = "Source";
                        break;
                }

                WriteJs(tp);

                this.ddltype.SelectedValue = tp;
            }
        }

        private void InitData()
        {
            if (this.HasPopedom("GlobalAnalysis"))
            {
                this.ddlUser.SelectedValue = (Session["UserInfo"] as Model.UserInfo).UserId.ToString();
            }
        }

        private void BindData()
        {
            this.ddltype.Items.AddRange(new ListItem[] 
            { 
                new ListItem("客户来源", "Source")
                , new ListItem("客户状态", "State")
                , new ListItem("客户类型", "Type")
                , new ListItem("主营行业", "Trade")                
                , new ListItem("地区", "Area")
                , new ListItem("客户发展月趋势图", "Trend") 
            });

            if (this.HasPopedom("GlobalAnalysis"))
            {
                this.ddlUser.DataSource = userBLL.GetList();
                this.ddlUser.DataBind();

                this.ddlUser.Items.Insert(0, new ListItem("全局分析…", "0"));

                this.ddltype.Items.Add(new ListItem("负责人", "Assign"));
            }
        }

        protected override void SetContorlVisable()
        {
            //this.lchangepass.Visible = true;
            //this.lrole.Visible = this.HasPopedom("Role");
            //this.lrpt.Visible = this.HasPopedom("GlobalAnalysis");
            //this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            //this.lusermanage.Visible = this.HasPopedom("UserView");

            this.ddlUser.Visible = this.HasPopedom("GlobalAnalysis");
        }

        private string clientJscript;

        public string ClientJscript
        {
            get { return clientJscript; }
            set { clientJscript = value; }
        }

        private void WriteJs(string type)
        {
            if (type == "None") return;

            string count = "Count";
            string displayName = "DisplayName";

            StringBuilder strJs = new StringBuilder(); 

            strJs.Append("<script type='text/javascript'>\n");
            strJs.Append("    YAHOO.util.Event.onDOMReady(function(){\n");
            strJs.Append("        YAHOO.widget.Chart.SWFURL = \"js/build/charts/assets/charts.swf\";\n");

            string json = GetJSonString(count, displayName, type);
            strJs.Append(json);
            strJs.Append("        var opinionData = new YAHOO.util.DataSource( YAHOO.example.publicOpinion );\n");
                strJs.Append("        opinionData.responseType = YAHOO.util.DataSource.TYPE_JSARRAY;\n");
                if (type != "Trend")
                {
                    strJs.Append("        opinionData.responseSchema = { fields: [ \"" + displayName + "\", \"" + count + "\" ] };\n");
                    strJs.Append("        var mychart = new YAHOO.widget.PieChart( \"chart\", opinionData,\n");
                    strJs.Append("        {\n");
                    strJs.Append("            dataField: \"" + count + "\",\n");
                    strJs.Append("            categoryField: \"" + displayName + "\",\n");
                    strJs.Append("            style:\n");
                    strJs.Append("            {\n");
                    strJs.Append("                padding: 20,\n");
                    strJs.Append("                legend:\n");
                    strJs.Append("                {\n");
                    strJs.Append("                    display: \"right\",\n");
                    strJs.Append("                    padding: 10,\n");
                    strJs.Append("                    spacing: 5,\n");
                    strJs.Append("                    font:\n");
                    strJs.Append("                    {\n");
                    strJs.Append("                        family: \"Arial\",\n");
                    strJs.Append("                        size: 13\n");
                    strJs.Append("                    }\n");
                    strJs.Append("                }\n");
                    strJs.Append("            }\n");
                    strJs.Append("        });\n");
                }
                else
                {
                    strJs.Append("        opinionData.responseSchema = { fields: [ \"" + count + "\", \"" + displayName + "\"] };\n");
                    strJs.Append("        var seriesDef = [ { displayName: \"" + displayName + "\", yField: \"" + count + "\" } ];\n");
                    strJs.Append("        YAHOO.example.formatCurrencyAxisLabel = function( value )\n");
                    strJs.Append("        {\n");
                    strJs.Append("              return YAHOO.util.Number.format( value,\n");
                    strJs.Append("              {\n");
                    strJs.Append("                  thousandsSeparator: \",\",\n");
                    strJs.Append("                  decimalPlaces: 0\n");
                    strJs.Append("              });\n");
                    strJs.Append("        }\n");

                    strJs.Append("        YAHOO.example.getDataTipText = function( item, index, series )\n");
                    strJs.Append("        {\n");
//                    var toolTipText = item.DisplayName+\titem.Count";
                    strJs.Append("              var toolTipText = item." + displayName + "+\"\\t\"+item." + count + ";\n");
                    strJs.Append("              return toolTipText;\n");
                    strJs.Append("        }\n");

                    strJs.Append("        var currencyAxis = new YAHOO.widget.NumericAxis();\n");
                    strJs.Append("        currencyAxis.minimum = 10;\n");
                    strJs.Append("        currencyAxis.labelFunction = YAHOO.example.formatCurrencyAxisLabel;\n");

                    strJs.Append("        var mychart = new YAHOO.widget.LineChart( \"chart\", opinionData,\n");
                    strJs.Append("        {\n");
                    strJs.Append("              series: seriesDef,\n");
                    strJs.Append("              xField: \"" + displayName + "\",\n");
                    strJs.Append("              yAxis: currencyAxis,\n");
                    strJs.Append("              dataTipFunction: YAHOO.example.getDataTipText\n");
                    strJs.Append("        });\n");
                }

            strJs.Append("    });\n");
            strJs.Append("</script>");


            clientJscript = strJs.ToString();
        }

        public string GetJSonString(string col1, string col2, string type)
        {
            string result = "";
            string head = "YAHOO.example.publicOpinion =\n[";

            DataTable data = new DataTable();

            string userId = (Session["UserInfo"] as Model.UserInfo).UserId.ToString();
            
            if (this.HasPopedom("GlobalAnalysis"))
            {
                userId = this.ddlUser.SelectedValue;
            }

            switch (type)
            {
                case "Area":
                    data = customerBLL.AnalyseByArea(this.Area1.CityId, userId);
                    break;
                case "Trend":
                    data = customerBLL.AnalyseByTrend(DateTime.Now, userId);
                    break;
                case "None":
                    break;
                case "Assign":
                    if (this.HasPopedom("GlobalAnalysis"))
                    {
                        data = customerBLL.AnalysebyAssign();
                    }
                    else 
                    {
                        this.ValidatePopedom("GlobalAnalysis");
                    }
                    break;
                default:
                    EAPP.CRM.Model.AnalyseCondition condition = new EAPP.CRM.Model.AnalyseCondition();
                    condition.AssignObject = "user";
                    condition.AssignObjectId = EAPP.CRM.Common.MyConvert.GetInt32(userId);
                    condition.AnalyseType = (EAPP.CRM.Model.AnalyseType)Enum.Parse(typeof(EAPP.CRM.Model.AnalyseType), type);
                    data = customerBLL.Analyse(condition);
                    break;
            }

            int rowCount = data.Rows.Count;

            if (type != "Trend")
            {
                if (rowCount < 1) 
                {
                    result += ",{\"" + col1 + "\":\"0\",\"" + col2 + "\":\"无数据\"}";
                }
                else
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        DataRow dr = data.Rows[i];
                        result += ",{\"" + col1 + "\":\"" + dr[col1].ToString() + "\",\"" + col2 + "\":\"" + dr[col2].ToString() + "\"}";
                    }
                }
            }
            else
            {
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow dr = data.Rows[i];
                    string Time = string.Format("{0}年{1}月", dr["Year"].ToString(), dr["Month"].ToString());
                    result += ",{\"" + col1 + "\":\"" + dr[col1].ToString() + "\",\"" + col2 + "\":\"" + Time + "\"}";
                }
            }
            
            if (result.IndexOf(',') == 0)
            {
                result = result.Substring(1);
            }
            
            result = head + result;
            result +="];";
            return result;
        }

        protected void btnAnalyse_Click(object sender, EventArgs e)
        {
            string type = this.ddltype.SelectedValue;
            WriteJs(type);
        }
    }
}