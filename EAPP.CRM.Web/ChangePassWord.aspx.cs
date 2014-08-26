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
    public partial class ChangePassWord : BasePage
    {
        protected EAPP.CRM.BLL.User userBLL = new EAPP.CRM.BLL.User();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void SetContorlVisable()
        {
            this.basedata.Visible = this.HasPopedom("BaseDataManage");

            this.lchangepass.Visible = true;
            this.lrole.Visible = this.HasPopedom("Role");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Model.UserInfo info = Session["UserInfo"] as Model.UserInfo;
            this.lblMessage.Text = "";
            lblSucMessage.Text = "";
            if (EAPP.CRM.Common.SecurityUtil.MD5(this.txtOldPassWord.Text) != info.Password)
            {
                this.lblMessage.Text = "输入的旧密码错误。";
            }
            else
            {
                string new1 = this.txtNewPassWord.Text;
                string new2 = this.txtReNewPwd.Text;

                if (new1 != new2)
                {
                    this.lblMessage.Text = "两次输入的新密码不一致。";
                }
                else
                {
                    info.Password = EAPP.CRM.Common.SecurityUtil.MD5(new1);

                    int res = userBLL.Update(info);

                    if (res > 0)
                    {
                        Session["UserInfo"] = info;
                        lblSucMessage.Text = "修改成功";
                    }
                }
            }
        }
    }
}
