<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddContacts.aspx.cs" Inherits="EAPP.CRM.Web.AddContacts"
    MasterPageFile="~/MainTemplate.Master" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">
    <div id="content">
        <div id="left">
            <div class="leftTitle">
                操作</div>
            <ul class="list">
                <li><a href="CustomerList.aspx?type=0" id="mycus">我的客户</a> </li>
                <li><a href="CustomerList.aspx?type=1" id="sharecus">共享客户</a></li>
                <li><a href="CustomerList.aspx?type=3" id="recyclecus">回收站</a></li>
                <li><a href="SearchContact.aspx">查询联系人</a></li>
                <li><a href="SendMail.aspx">给联系人发邮件</a></li>
            </ul>
        </div>
        <div id="right">
            <h4>
                新增联系人资料</h4>
            <table border="0" style="width: 100%" class="inputTable">
                <tr>
                    <th style="width: 15%">
                        中文名:
                    </th>
                    <td style="width: 35%">
                        <asp:TextBox ID="txtCnName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCnName"
                            Display="Dynamic" ErrorMessage="请填写中文名"></asp:RequiredFieldValidator>
                    </td>
                    <th style="width: 15%">
                        英文名:&nbsp;
                    </th>
                    <td style="width: 35%">
                        &nbsp;
                        <asp:TextBox ID="txtEnName" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        昵称:
                    </th>
                    <td>
                        <asp:TextBox ID="txtNickName" runat="server">
                        </asp:TextBox>
                    </td>
                    <th>
                        性别:
                    </th>
                    <td>
                        <asp:RadioButton ID="rbtnMale" Checked="true" runat="server" Text="男" GroupName="Sex" />
                        <asp:RadioButton ID="rbtnFemale" runat="server" Text="女" GroupName="Sex" />
                    </td>
                </tr>
                <tr>
                    <th>
                        称呼:
                    </th>
                    <td>
                        <asp:TextBox ID="txtSalutation" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        职务:
                    </th>
                    <td>
                        <asp:TextBox ID="txtPost" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        常用电子邮件:
                    </th>
                    <td>
                        <asp:TextBox ID="txtContactEmail1" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContactEmail1"
                            Display="Dynamic" ErrorMessage="电子邮件格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                    <th>
                        备用邮件:
                    </th>
                    <td>
                        <asp:TextBox ID="txtContactEmail2" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactEmail2"
                            Display="Dynamic" ErrorMessage="电子邮件格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        首要联系人:
                    </th>
                    <td>
                        <asp:RadioButton ID="rbtnMain" runat="server" Checked="true" GroupName="main" Text="是" />
                        <asp:RadioButton ID="rbtnNotMain" runat="server" GroupName="main" Text="否" />
                    </td>
                    <th>
                        手机:
                    </th>
                    <td>
                        <asp:TextBox ID="txtContactMobilePhone" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContactMobilePhone"
                            Display="Dynamic" ErrorMessage="手机格式不正确" ValidationExpression="(13[0-9]|15[0|1|2|3|6|7|8|9]|18[8|9])\d{8}"></asp:RegularExpressionValidator>
                    </td>
                </tr>                
                <tr>
                    <th>
                        电话:
                    </th>
                    <td>
                        <asp:TextBox ID="txtContactTel" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtContactTel"
                            Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                    </td>
                    <th>
                        传真:
                    </th>
                    <td>
                        <asp:TextBox ID="txtContactFax" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtContactFax"
                            Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                    </td>
                </tr>                
                <tr>
                    <th>
                        即时通讯工具:
                    </th>
                    <td>
                        <asp:TextBox ID="txtIm" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        地区:
                    </th>
                    <td>
                        <uc1:Area ID="Area1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        详细地址:
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="txtContactAddress" runat="server" TextMode="MultiLine" Columns="70"
                            Rows="2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        备注:
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="txtContactRemark" runat="server" TextMode="MultiLine" Columns="70"
                            Rows="3"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="actionArea">
                <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="bigBtn" />
                <input type="reset" id="btnReset" value="重置" class="bigBtn" />
            </div>
        </div>
    </div>
</asp:Content>
