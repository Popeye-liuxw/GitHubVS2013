<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmtpConfig.aspx.cs" Inherits="EAPP.CRM.Web.SmtpConfit"
    MasterPageFile="~/MainTemplate.Master" %>

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
            <h4>
                SMTP服务器配置
            </h4>
            <table style="width: 100%; border: 0px" class="inputTable">
                <tr>
                    <th>
                        发件人Email:
                    </th>
                    <td>
                        <asp:TextBox ID="txtFixEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFixEmail"
                            Display="Dynamic" ErrorMessage="必填项"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFixEmail"
                            Display="Dynamic" ErrorMessage="Email格式错误" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                    <th>
                        发件人姓名:
                    </th>
                    <td>
                        <asp:TextBox ID="txtdisplayName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        smtp服务器地址:
                    </th>
                    <td>
                        <asp:TextBox ID="txtServer" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtServer"
                            Display="Dynamic" ErrorMessage="必填项"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtServer"
                            Display="Dynamic" ErrorMessage="服务器格式不正确" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                    </td>
                    <th>
                        smtp端口号:
                    </th>
                    <td>
                        <asp:TextBox ID="txtPort" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPort"
                            Display="Dynamic" ErrorMessage="SMTP端口号必填"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        用户名:
                    </th>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUser"
                            Display="Dynamic" ErrorMessage="必填项"></asp:RequiredFieldValidator>
                    </td>
                    <th>
                        密码:
                    </th>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPwd"
                            Display="Dynamic" ErrorMessage="必填项"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="actionArea">
                <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="bigBtn" />
            </div>
        </div>
    </div>
</asp:Content>
