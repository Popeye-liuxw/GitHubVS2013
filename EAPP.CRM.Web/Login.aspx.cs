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
    public partial class Login : System.Web.UI.Page
    {
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();
        protected EAPP.CRM.BLL.Popedom popedomBLL = new EAPP.CRM.BLL.Popedom();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) { }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string loginName = this.txtUserName.Text.Trim();
            string passWord = this.txtPassWord.Text.Trim();

            passWord = EAPP.CRM.Common.SecurityUtil.MD5(passWord);

            Model.UserInfo userInfo = userBLL.GetItem(loginName);
            if (userInfo == null)
            {
                this.lblMessage.Text = "用户名错误。";
            }
            else
            {
                if (!passWord.Equals(userInfo.Password))
                {
                    this.lblMessage.Text = "密码错误。";
                }
                else
                {
                    System.Collections.Generic.IDictionary<string, bool> popedom = popedomBLL.GetUserPopedom(userInfo);
                    
                    Session["PopedomInfo"] = popedom;
                    Session["UserInfo"] = userInfo;
                    Response.Redirect("Main.aspx");
                }
            }
        }
    }
}
