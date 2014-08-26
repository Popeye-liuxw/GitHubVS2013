<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="EAPP.CRM.Web.Main"
    MasterPageFile="~/MainTemplate.Master" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="a" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">



    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="js/build/json/json-min.js"></script>

    <script type="text/javascript" src="js/build/element/element-min.js"></script>

    <script type="text/javascript" src="js/build/datasource/datasource-min.js"></script>

    <script type="text/javascript" src="js/build/swf/swf-min.js"></script>

    <script type="text/javascript" src="js/build/charts/charts-min.js"></script>

    <script type='text/javascript' src='js/build/yahoo-dom-event/yahoo-dom-event.js'></script>

    <div id="content">
        <table border="0" cellpadding="3" cellspacing="0">
            <tr>
                <td width="590px">
                    <h4 class="h4title">常见操作</h4>
                    <ul class="mainbd h80 link">
                        <li><a href="AddCustomer.aspx" title="">新增客户</a></li>
                        <li><a href="SearchContact.aspx" title="">联系人查询</a></li>
                        <li><a href="SendMail.aspx" title="">联系联系人</a></li>
                        <li><a href="CustomerList.aspx?type=0" title="">我的客户</a></li>
                        <li><a href="CustomerList.aspx?type=1" title="">共享客户</a></li>
                        <li><a href="Report.aspx" title="">报表</a></li>
                    </ul>
                </td>
                <td width="380px">
                    <h4 class="h4title">快速查询</h4>
                    <div class="mainbd h80 search">
                        <asp:DropDownList ID="ddltype" runat="server">
                            <asp:ListItem Text="客户" Value="0">
                            </asp:ListItem>
                            <asp:ListItem Text="联系人" Value="1">
                            </asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="btn"/>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td>
                <br/>
                <div id="report1">
                    <%= this.WriteJs("Trend", "Trend")%>
                    <div>
                        <div class="mainct">客户月发展趋势</div>
                        <div id="Trend" class="mainbd lchart">
                        </div>
                    </div>
                </div>
                </td>
                <td>
                <br/>
                    <div id="report2">
                        <%= this.WriteJs("Trade", "charttype")%>
                        <div>
                            <div class="mainct">客户行业分析
                                 &nbsp;<a href="Report.aspx" title="更多报表">更多</a>
                            </div>
                            <div id="charttype" class="mainbd rchart">
                            </div>
                        </div>
                    </div>
                   
                </td>
            </tr>
        </table>
        <br/>
        <div style="clear: both;" />
    </div>
</asp:Content>
