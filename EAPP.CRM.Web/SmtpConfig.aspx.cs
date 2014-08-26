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
    public partial class SmtpConfit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                EAPP.CRM.Config.EmailInfo info = EAPP.CRM.Config.EmailConfig.GetEmailConfig();

                this.txtUser.Text = info.User;
                this.txtServer.Text = info.Server;
                this.txtPwd.Text = info.Pwd;
                this.txtPort.Text = info.Port.ToString();
                this.txtFixEmail.Text = info.FixEmail;
                this.txtdisplayName.Text = info.DisplayName;
            }
        }

        protected override string Action
        {
            get
            {
                return "SMTPConfig";
            }
        }

        protected override void SetContorlVisable()
        {
            this.basedata.Visible = this.HasPopedom("BaseDataManage");

            this.lchangepass.Visible = true;
            this.lrole.Visible = this.HasPopedom("Role");
            //this.lrpt.Visible = this.HasPopedom("GlobalAnalysis");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            EAPP.CRM.Config.EmailInfo info = new EAPP.CRM.Config.EmailInfo();

            info.DisplayName = this.txtdisplayName.Text.Trim();
            info.FixEmail = this.txtFixEmail.Text.Trim();
            info.Port = EAPP.CRM.Common.MyConvert.GetInt32(this.txtPort.Text.Trim());
            info.Pwd = this.txtPwd.Text.Trim();
            info.Server = this.txtServer.Text.Trim();
            info.User = this.txtUser.Text;

            EAPP.CRM.Config.EmailConfig.SaveEmailConfig(info);

        }
    }
}
