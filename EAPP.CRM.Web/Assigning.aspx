<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assigning.aspx.cs" Inherits="EAPP.CRM.Web.Assigning" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script type="text/javascript" src="JS/base.js"></script>

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript">

        function GetUserDataOrDeptData(val)
        {
            var result = EAPP.CRM.Web.Assigning.GetUserDataOrDeptData(val).value;
            
            var ddl = $("ddlAssignObject");
            
            ddl.length = 0;
            
            if (val == 'user')
            {
                for (var i=0; i < result.Rows.length; i++)  
                {
                    ddl.options.add(new Option(result.Rows[i].CnName,result.Rows[i].UserId));
                }
            }
            else if (val == 'dept')
            {
                for(var k=0; k < result.Rows.length; k++)  
                {
                    ddl.options.add(new Option(result.Rows[k].DeptName,result.Rows[k].DeptId));
                }
            }
        }
        
        function update()
        {
            var ddl = $("ddlAssignObject");
            $("<%= this.AssignObjectId.ClientID %>").value = ddl.value;        
        }
        
        function assignCustomer()
        {
            var type = "user";
            if ($("<%= this.rbtnUser.ClientID %>").checked)
                type = "user";
            if ($("<%= this.rbtnDept.ClientID %>").checked)
                type = "dept";
                
            var res = EAPP.CRM.Web.Assigning.btnOk_Click('<%= Request.QueryString["ids"] %>',type,$("ddlAssignObject").value).value;
            top.window.location.reload();
        }
        
        
        YAHOO.util.Event.onDOMReady(function(){        
            GetUserDataOrDeptData('user');            
            update();
        });
        
    </script>

</head>
<body style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px;">
    <form id="form1" runat="server">
    <div style="width: 250px; height: 100px;">
        <div style="text-align: center; line-height: 24px; padding-bottom:38px; padding-top:30px;">
            <input type="hidden" name="AssignObjectId" id="AssignObjectId" runat="server" />
            <input type="radio" name="assignObject" runat="server" id="rbtnUser" value="user"
                onclick="GetUserDataOrDeptData('user')" checked="true" />用户
            <input type="radio" name="assignObject" runat="server" id="rbtnDept" value="dept"
                onclick="GetUserDataOrDeptData('dept')" />部门
            <select id="ddlAssignObject" name="ddlAssignObject" onchange="update()">
            </select>
            <asp:Button ID="btnOk" runat="server" OnClientClick="return assignCustomer()" Text="确定" />
        </div>
    </div>
    </form>
</body>
</html>
