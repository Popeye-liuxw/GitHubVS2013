<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EAPP.CRM.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统登录</title>
    <link href="css/login.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
 
        <table border="0" class="loginTable" cellpadding="0" cellspacing="0">
            <tr>
                <td class="info">
                    <div class="name">ECRM客户管理系统</div>
                    <div class="copy">EAPP CRM Copyright © 2010 EAPP Inc. All rights reserved. </div>
                </td>
                <td class="frm">
                    用户名:<br/>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" MaxLength="20"></asp:TextBox>
                    <br/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空。"
                        ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>
                    <br/>
                    密&nbsp;&nbsp;&nbsp;码:<br/>
                    <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" CssClass="txt" MaxLength="20">000000</asp:TextBox>
                    <br/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空。"
                        ControlToValidate="txtPassWord" Display="Dynamic"></asp:RequiredFieldValidator>
                        
                    <br/>
                    <asp:Button ID="btnOK" runat="server" Text="登陆" OnClick="btnOK_Click" CssClass="btn"/><input id="BtnReset" type="reset" class="btn"/>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
                </td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
</html>
