<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditContacts.aspx.cs" Inherits="EAPP.CRM.Web.EditContacts"
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
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <h4>
                        编辑联系人资料</h4>
                    <table border="0" style="width: 100%" class="inputTable">
                        <tr>
                            <th style="width: 15%">
                                中文名:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtCnName" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                英文名:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtEnName" runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                昵称:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtNickName" runat="server">
                                </asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                性别:
                            </th>
                            <td style="width: 35%">
                                <asp:RadioButton ID="rbtnMale" runat="server" Checked="true" GroupName="Sex" Text="男" />
                                <asp:RadioButton ID="rbtnFemale" runat="server" GroupName="Sex" Text="女" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                称呼:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtSalutation" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                职务:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtPost" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                电子邮件:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtContactEmail1" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                备用电子邮件:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtContactEmail2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                首要联系人:
                            </th>
                            <td style="width: 35%">
                                <asp:RadioButton ID="rbtnMain" runat="server" Checked="true" GroupName="main" Text="是" />
                                <asp:RadioButton ID="rbtnNotMain" runat="server" GroupName="main" Text="否" />
                            </td>
                            <th style="width: 15%">
                                手机:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtContactMobilePhone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                电话:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtContactTel" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                传真:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtContactFax" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                地区:
                            </th>
                            <td style="width: 35%">
                                <uc1:Area ID="Area1" runat="server" />
                            </td>
                            <th style="width: 15%">
                                即时通讯工具:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtIm" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                详细地址:
                            </th>
                            <td style="width: 35%" colspan="3">
                                <asp:TextBox ID="txtContactAddress" runat="server" TextMode="MultiLine" Rows="2"
                                    Columns="70"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                备注:
                            </th>
                            <td style="width: 35%" colspan="3">
                                <asp:TextBox ID="txtContactRemark" runat="server" TextMode="MultiLine" Rows="3" Columns="70"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="bigBtn" />
                        <input type="reset" id="btnReset" value="重置" class="bigBtn" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
