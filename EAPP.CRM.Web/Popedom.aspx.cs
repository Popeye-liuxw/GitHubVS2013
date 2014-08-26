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
    public partial class Popedom : BasePage
    {
        EAPP.CRM.BLL.Popedom popedomBLL = new EAPP.CRM.BLL.Popedom();
        EAPP.CRM.BLL.Role roleBLL = new EAPP.CRM.BLL.Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                BindData();
            }
        }


        protected override void SetContorlVisable()
        {
            this.basedata.Visible = this.HasPopedom("BaseDataManage");

            this.lchangepass.Visible = true;
            this.lrole.Visible = this.HasPopedom("Role");
            this.lsmtp.Visible = this.HasPopedom("SMTPConfig");
            this.lusermanage.Visible = this.HasPopedom("UserView");
        }

        protected override string Action
        {
            get
            {
                return "Role";
            }
        }

        protected override void ValidatePopedom()
        {
            string uid = Request.QueryString["rid"];
            if (!string.IsNullOrEmpty(uid))
            {
                base.ValidatePopedom();
            }
        }

        private void BindData()
        {
            this.MultiView1.ActiveViewIndex = 1;
            string rid = Request.QueryString["rid"];
            if (string.IsNullOrEmpty(rid))
            {
                this.lblMessage.Text = "缺少必要参数。";
            }
            else
            {
                EAPP.CRM.Model.RoleInfo info = roleBLL.GetItem(EAPP.CRM.Common.MyConvert.GetInt32(rid));

                if (info == null)
                {
                    this.lblMessage.Text = "不存在该角色，或该角色已经被删除。";
                }
                else 
                {
                    this.MultiView1.ActiveViewIndex = 0;

                    pnlRole1.Enabled = info.RoleName != "系统管理员";                    
                    
                    this.txtRoleName.Text = info.RoleName;
                    this.hdRoleId.Value = info.RoleId.ToString();

                    DataTable table = popedomBLL.GetList(rid);

                    ControlCollection contorls = this.pnlRole.Controls;

                    for (int i = 0; i < contorls.Count; i++)
                    {
                        System.Web.UI.Control ctl = contorls[i];
                        if (ctl.GetType() == typeof(HtmlInputCheckBox))
                        {
                            HtmlInputCheckBox ck = (HtmlInputCheckBox)ctl;
                            for (int k = 0; k < table.Rows.Count; k++)
                            {
                                DataRow dr = table.Rows[k];
                                if (ck.Value == dr["PopedomItem"].ToString())
                                {
                                    ((HtmlInputCheckBox)ctl).Checked = "0" == dr["IsAllow"].ToString() ? false : true;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            ControlCollection contorls = this.pnlRole.Controls;

            popedomBLL.DeleteByRoleId(this.hdRoleId.Value);

            for (int i = 0; i < contorls.Count; i++)
            {
                System.Web.UI.Control ctl = contorls[i];
                if (ctl.GetType() == typeof(HtmlInputCheckBox))
                {
                    HtmlInputCheckBox ck = (HtmlInputCheckBox)ctl;

                    EAPP.CRM.Model.PopedomInfo info = new EAPP.CRM.Model.PopedomInfo();
                    info.PopedomItem = ck.Value;
                    info.RoleId = EAPP.CRM.Common.MyConvert.GetInt32(this.hdRoleId.Value);
                    info.IsAllow = (short)(ck.Checked ? 1 : 0);

                    popedomBLL.Insert(info);
                }
            }

            Response.Redirect("Role.aspx");
        }
    }
}
