using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace EAPP.CRM.Web
{
    public class BasePage : System.Web.UI.Page
    {
        private string action = "";

        protected virtual string Action
        {
            get { return action; }
        }

        protected override void OnInit(EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("login.aspx");
            }
            ValidatePopedom();
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.IsPostBack) 
            {
                if (Request.UrlReferrer != null)
                {
                    Session["r"] = Request.UrlReferrer.ToString();
                }
            }

            SetContorlVisable();

            base.OnLoad(e);
        }

        protected virtual void ValidatePopedom() 
        {
            this.ValidatePopedom(this.Action);
        }

        protected void ValidatePopedom(string popedomItem) 
        {
            System.Collections.Generic.Dictionary<string, bool> popedoms = Session["PopedomInfo"] as System.Collections.Generic.Dictionary<string, bool>;
            if (this.Action != "")
            {
                if (popedoms.ContainsKey(popedomItem))
                {
                    if (!popedoms[popedomItem])
                    {
                        Response.Write(@"<script>alert('您没有权限访问该页面，请与管理员联系。');document.location.href='Main.aspx'</script>");
                        Response.End();
                    }
                }
                else 
                {
                    Response.Write(@"<script>alert('您没有权限访问该页面，请与管理员联系。');document.location.href='Main.aspx'</script>");
                    Response.End();
                }
            }
        }

        protected bool HasPopedom(string popedomItem) 
        {
            System.Collections.Generic.Dictionary<string, bool> popedoms = Session["PopedomInfo"] as System.Collections.Generic.Dictionary<string, bool>;
            if (popedoms.ContainsKey(popedomItem) && popedoms[popedomItem]) 
            {
                return true;
            }
            return false;
        }

        protected virtual void SetContorlVisable() 
        { }
    }
}
