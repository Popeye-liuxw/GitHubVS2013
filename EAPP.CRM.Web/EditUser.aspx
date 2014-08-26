<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="EAPP.CRM.Web.EditUser"
    MasterPageFile="~/MainTemplate.Master" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
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
                编辑用户资料</h4>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="border: 0px; width: 100%" class="inputTable">
                        <tr>
                            <th style="width: 10%">
                                登陆名:
                            </th>
                            <td style="width: 40%">
                                <asp:TextBox ID="txtLoginName" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th style="width: 10%">
                                角色:
                            </th>
                            <td style="width: 40%">
                                <asp:DropDownList ID="ddlRole" runat="server" DataTextField="RoleName" DataValueField="RoleId">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="ddlRole"
                                    ErrorMessage="请选择角色" ClientValidationFunction="checkDll"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                中文名:
                            </th>
                            <td>
                                <asp:TextBox ID="txtCnName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCnName"
                                    Display="Dynamic" ErrorMessage="中文名是必填项"></asp:RequiredFieldValidator>
                            </td>
                            <th>
                                英文名:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEnName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                所在部门:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlDept" runat="server" DataTextField="DeptName" DataValueField="DeptId">
                                </asp:DropDownList>
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
                                工作电话:
                            </th>
                            <td>
                                <asp:TextBox ID="txtWorkPhone" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtWorkPhone"
                                    Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                家庭电话:
                            </th>
                            <td>
                                <asp:TextBox ID="txtHomePhone" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone"
                                    Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                手机:
                            </th>
                            <td>
                                <asp:TextBox ID="txtMobilePhone" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="手机号码格式错误。"
                                    ValidationExpression="(13[0-9]|15[0|1|2|3|6|7|8|9]|18[8|9])\d{8}" ControlToValidate="txtMobilePhone"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                传真:
                            </th>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFax"
                                    Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                常用Email:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmail1" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtEmail1"
                                    Display="Dynamic" ErrorMessage="Email格式错误。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                备用Email:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmail2" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtEmail2"
                                    Display="Dynamic" ErrorMessage="Email格式错误。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                身份证号:
                            </th>
                            <td>
                                <asp:TextBox ID="txtIcCard" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtIcCard"
                                    Display="Dynamic" ErrorMessage="身份证格式错误。" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                Im:
                            </th>
                            <td>
                                <asp:TextBox ID="txtIm" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                所在地区:
                            </th>
                            <td>
                                <uc1:Area ID="Area1" runat="server" />
                            </td>
                            <th>
                            </th>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                详细地址:
                            </th>
                            <td colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Columns="80" Rows="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                备注:
                            </th>
                            <td colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Columns="80" Rows="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                密码:
                            </th>
                            <td>
                                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                                注:若不修改密码请不要填写密码
                            </td>
                            <th>
                            </th>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="bigBtn" OnClick="btnOk_Click" />
                        <input id="Reset1" type="reset" value="重置" class="bigBtn" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
