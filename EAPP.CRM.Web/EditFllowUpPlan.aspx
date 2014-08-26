<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFllowUpPlan.aspx.cs"
    Inherits="EAPP.CRM.Web.EditFllowUpPlan" MasterPageFile="~/MainTemplate.Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="contentPlaceHolderMain" runat="server">

    <script type="text/javascript" src="JS/base.js"></script>

    <link rel="stylesheet" type="text/css" href="js/build/calendar/assets/skins/sam/calendar.css" />

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="js/build/calendar/calendar-min.js"></script>

    <div id="mycal">
    </div>
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
                编辑跟进记录</h4>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table border="0" style="width: 100%" class="inputTable">
                        <tr>
                            <th style="width: 15%">
                                客户名称:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                &nbsp;
                            </th>
                            <td style="width: 35%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <th>
                                联系时间:
                            </th>
                            <td>
                                <%--<asp:TextBox ID="txtContactTime" runat="server" ReadOnly="true"></asp:TextBox>--%>
                                <input type="text" id="txtContactTime" name="txtContactTime" runat="server" readonly="readonly" />
                                <button type="button" id="Button1" title="Show Calendar" onclick="selectData($('<%= this.txtContactTime.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactTime"
                                    Display="Dynamic" ErrorMessage="请选择时间"></asp:RequiredFieldValidator>
                            </td>
                            <th>
                                状态:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server">
                                    <asp:ListItem Value="0">空</asp:ListItem>
                                    <asp:ListItem Value="planning">计划中</asp:ListItem>
                                    <asp:ListItem Value="processing">进行中</asp:ListItem>
                                    <asp:ListItem Value="end">完成</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="ddlState"
                                    Display="Dynamic" ErrorMessage="请选择状态" ClientValidationFunction="checkDll"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                联系人:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlContact" runat="server" DataTextField="CnName" DataValueField="ContactId">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="ddlContact"
                                    Display="Dynamic" ErrorMessage="请选择联系人" ClientValidationFunction="checkDll"></asp:CustomValidator>
                            </td>
                            <th>
                                联系方式:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlContactInfo" runat="server">
                                    <asp:ListItem Value="0">空</asp:ListItem>
                                    <asp:ListItem Value="tel">电话</asp:ListItem>
                                    <asp:ListItem Value="fax">传真</asp:ListItem>
                                    <asp:ListItem Value="visit">登门拜访</asp:ListItem>
                                    <asp:ListItem Value="email">邮件</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                兴趣点:
                            </th>
                            <td>
                                <asp:TextBox ID="txtInterest" runat="server" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox>
                            </td>
                            <th>
                                异议点:
                            </th>
                            <td>
                                <asp:TextBox ID="txtDissent" runat="server" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                跟踪后客户状态:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlCustomerState" runat="server" DataTextField="Name" DataValueField="StateId">
                                </asp:DropDownList>
                            </td>
                            <th>
                                跟进结果:
                            </th>
                            <td>
                                <asp:TextBox ID="txtResult" runat="server" Columns="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                下次跟进时间:
                            </th>
                            <td>
                                <%--<asp:TextBox ID="txtNextTime" runat="server" ReadOnly="true"></asp:TextBox>--%>
                                <input type="text" id="txtNextTime" name="txtNextTime" runat="server" readonly="readonly" />
                                <button type="button" id="Button2" title="Show Calendar" onclick="selectData($('<%= this.txtNextTime.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>
                            </td>
                            <th>
                                跟进点描述:
                            </th>
                            <td>
                                <asp:TextBox ID="txtNextTiming" runat="server" Columns="30"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="bigBtn" OnClick="btnOk_Click" />
                        <input type="reset" id="btnReset" value="重置" class="bigBtn" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
