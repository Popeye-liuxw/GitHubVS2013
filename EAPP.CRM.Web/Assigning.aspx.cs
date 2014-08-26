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
    public partial class Assigning : BasePage
    {
        protected EAPP.CRM.BLL.Customer customerBLL = new EAPP.CRM.BLL.Customer();

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack) 
            {
                AjaxPro.Utility.RegisterTypeForAjax(typeof(Assigning));         
            }
        }

        protected override string Action
        {
            get
            {
                return "CustomerAssign";
            }
        }

        /// <summary>
        /// 根据userOrDept的值返回用户列表或者部门列表
        /// </summary>
        /// <param name="userOrDept">只能为user或者dept</param>
        /// <returns>根据userOrDept的值返回用户列表或者部门列表</returns>
        [AjaxPro.AjaxMethod]
        public DataTable GetUserDataOrDeptData(string userOrDept)
        {
            return Ajax.GetUserDataOrDeptData(userOrDept);
        }

        [AjaxPro.AjaxMethod]
        public int btnOk_Click(string ids,string type,string id)
        {
            string[] parm = new string[3];

            //string ids = Request.QueryString["ids"];

            if (ids.IndexOf(",") == 0)
            {
                ids = ids.Substring(1);
            }

            parm[0] = ids;
            parm[1] = type;
            parm[2] = id;

            return customerBLL.Assign(parm);            
        }
    }
}
