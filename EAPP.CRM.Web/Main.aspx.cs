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
    public partial class Main : BasePage
    {
        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        public string WriteJs(string type,string id)
        {
            if (type == "None") return "";

            StringBuilder strJs = new StringBuilder();

            strJs.Append("<script type='text/javascript'>\n");
            strJs.Append("    YAHOO.util.Event.onDOMReady(function(){\n");
            strJs.Append("        YAHOO.widget.Chart.SWFURL = \"js/build/charts/assets/charts.swf\";\n");

            string json = GetJSonString(type);
            strJs.Append(json);
            strJs.Append("        var opinionData = new YAHOO.util.DataSource( YAHOO.example.publicOpinion );\n");
            strJs.Append("        opinionData.responseType = YAHOO.util.DataSource.TYPE_JSARRAY;\n");
            if (type != "Trend")
            {
                strJs.Append("        opinionData.responseSchema = { fields: [ \"DisplayName\", \"Count\" ] };\n");
                strJs.Append("        var mychart = new YAHOO.widget.PieChart( \"" + id + "\", opinionData,\n");
                strJs.Append("        {\n");
                strJs.Append("            dataField: \"Count\",\n");
                strJs.Append("            categoryField: \"DisplayName\",\n");
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
                strJs.Append("        opinionData.responseSchema = { fields: [ \"Count\", \"DisplayName\"] };\n");
                strJs.Append("        var seriesDef = [ { displayName: \"DisplayName\", yField: \"Count\" } ];\n");
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
                strJs.Append("              var toolTipText = item.DisplayName+\"\\t\"+item.Count;\n");
                strJs.Append("              return toolTipText;\n");
                strJs.Append("        }\n");

                strJs.Append("        var currencyAxis = new YAHOO.widget.NumericAxis();\n");
                strJs.Append("        currencyAxis.minimum = 20;\n");
                strJs.Append("        currencyAxis.labelFunction = YAHOO.example.formatCurrencyAxisLabel;\n");

                strJs.Append("        var mychart = new YAHOO.widget.LineChart( \"" + id + "\", opinionData,\n");
                strJs.Append("        {\n");
                strJs.Append("              series: seriesDef,\n");
                strJs.Append("              xField: \"DisplayName\",\n");
                strJs.Append("              yAxis: currencyAxis,\n");
                strJs.Append("              dataTipFunction: YAHOO.example.getDataTipText\n");
                strJs.Append("        });\n");
            }

            strJs.Append("    });\n");
            strJs.Append("</script>");


            return strJs.ToString();
        }

        private string GetJSonString(string type)
        {
            string result = "";
            string head = "YAHOO.example.publicOpinion =\n[";

            DataTable data = new DataTable();

            string userId = (Session["UserInfo"] as Model.UserInfo).UserId.ToString();

            switch (type)
            {
                case "Trend":
                    data = customerBLL.AnalyseByTrend(DateTime.Now, userId);
                    break;
                default:
                    EAPP.CRM.Model.AnalyseCondition condition = new EAPP.CRM.Model.AnalyseCondition();
                    condition.AssignObject = "user";
                    condition.AssignObjectId = EAPP.CRM.Common.MyConvert.GetInt32(userId);
                    condition.AnalyseType = (EAPP.CRM.Model.AnalyseType)Enum.Parse(typeof(EAPP.CRM.Model.AnalyseType), type);
                    data = customerBLL.Analyse(condition);
                    break;
            }

            if (type != "Trend")
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    result += ",{\"Count\":\"" + dr["Count"].ToString() + "\",\"DisplayName\":\"" + dr["DisplayName"].ToString() + "\"}";
                }
            }
            else
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];
                    string Time = string.Format("{0}年{1}月", dr["Year"].ToString(), dr["Month"].ToString());
                    result += ",{\"Count\":\"" + dr["Count"].ToString() + "\",\"DisplayName\":\"" + Time + "\"}";
                }
            }

            if (result.IndexOf(',') == 0)
            {
                result = result.Substring(1);
            }

            result = head + result;
            result += "];";
            return result;
        }
   
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "";
            string type = this.ddltype.SelectedValue;
            string name = this.txtName.Text;
            
            if ("0".Equals(type))
            {
                url = "CustomerList.aspx?type=2&key=" + name;
            }
            else 
            {
                url = "SearchContact.aspx?type=2&key=" + name;
            }

            Response.Redirect(url);
            
        }
    }
}
