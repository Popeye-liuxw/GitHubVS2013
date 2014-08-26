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
    public partial class Area : BasePage
    {        
        protected EAPP.CRM.BLL.Area areaBLL = new EAPP.CRM.BLL.Area();

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Area));
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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Model.AreaInfo info = new EAPP.CRM.Model.AreaInfo();
            info.AreaName = this.txtName.Text;
            info.ParentId = EAPP.CRM.Common.MyConvert.GetInt32(this.pid.Value);
            areaBLL.Insert(info);

            this.txtName.Text = "";
        }

        [AjaxPro.AjaxMethod]
        public DataTable GetCityData(string areaId)
        {
            return Ajax.GetAreaList(areaId);
        }

        [AjaxPro.AjaxMethod]
        public string[] GetCity(string areaId)
        {
            return Ajax.GetArea(areaId);
        }
    }
}
