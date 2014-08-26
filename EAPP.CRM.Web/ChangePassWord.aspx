<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassWord.aspx.cs"
    Inherits="EAPP.CRM.Web.ChangePassWord" MasterPageFile="~/MainTemplate.Master" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">
    <div id="content">
        <div id="left">
            <asp:Panel ID="basedata" runat="server">
                <div class="leftTitle">
                    基础数据维护</div>
                <ul class="list">
                    <li><a href="CustomerSource.aspx">客户来源</a></li>
                    <li><a href="CustomerState.aspx">客户状态</a></li>
                    <li><a href="CustomerType.aspx">客户类型</a></li>
                    <li><a href="Department.aspx">部门</a></li>
                    <li><a href="Area.aspx">地区</a></li>
                    <li><a href="CustomerTrade.aspx">行业</a></li>
                </ul>
            </asp:Panel>
            <div class="leftTitle">
                系统管理</div>
            <ul class="list">
                <li id="luserinfo" runat="server"><a href="EditUser.aspx">修改个人信息</a></li>
                <li id="lusermanage" runat="server"><a href="User.aspx">用户管理</a> </li>
                <li id="lsmtp" runat="server"><a href="SmtpConfig.aspx">Smtp服务器配置</a></li>
                <li id="lrole" runat="server"><a href="Role.aspx">角色</a> </li>
                <li id="lchangepass" runat="server"><a href="ChangePassWord.aspx">修改密码</a></li>
            </ul>
        </div>
        <div id="right">
            <h4 style="width:100%">
                修改密码
            </h4>
           
                    <table style="width: 100%; border: 0px;" class="inputTable">
                    <tr>
                    <td colspan="2" style="text-align:center;">
                        <b><asp:Label ID="lblSucMessage" Font-Size="14px" ForeColor="Red" runat="server" Text=""></asp:Label></b>
                    </td>
                        </tr>
                        <tr>
                            <th style="width: 45%">
                                旧密码:
                            </th>
                            <td style="width: 55%">
                                <asp:TextBox ID="txtOldPassWord" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassWord"
                                    Display="Dynamic" ErrorMessage="请输入旧密码."></asp:RequiredFieldValidator>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                新密码:
                            </th>
                            <td>
                                <asp:TextBox ID="txtNewPassWord" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassWord"
                                    Display="Dynamic" ErrorMessage="请输入新密码."></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord"
                                    ControlToValidate="txtReNewPwd" Display="Dynamic" ErrorMessage="两次输入的新密码不一致."></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                重复密码:
                            </th>
                            <td>
                                <asp:TextBox ID="txtReNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReNewPwd"
                                    Display="Dynamic" ErrorMessage="请再次输入新密码."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="bigBtn" OnClick="btnOk_Click" />
                        <input id="Reset1" type="reset" value="重置" class="bigBtn" />
                    </div>
        </div>
    </div>
</asp:Content>
