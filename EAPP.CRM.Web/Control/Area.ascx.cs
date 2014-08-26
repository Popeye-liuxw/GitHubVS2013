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

namespace EAPP.CRM.Web.Control
{
    public partial class Area : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Area));            
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

        public string CityId
        {
            get 
            {
                return this.result.Value; 
            }
            set 
            {
                this.result.Value = value; 
            }
        }

        private bool readOnly;

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }
    }

}