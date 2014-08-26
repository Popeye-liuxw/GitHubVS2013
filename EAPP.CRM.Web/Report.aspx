<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="EAPP.CRM.Web.Report"
    MasterPageFile="~/MainTemplate.Master" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">
    <link rel="stylesheet" type="text/css" href="js/build/fonts/fonts-min.css" />
    <style type="text/css">
        #chart
        {
            width: 750px;
            height: 400px;
        }
        .chart_title
        {
            display: block;
            font-size: 1.2em;
            font-weight: bold;
            margin-bottom: 0.4em;
        }
    </style>

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="js/build/json/json-min.js"></script>

    <script type="text/javascript" src="js/build/element/element-min.js"></script>

    <script type="text/javascript" src="js/build/datasource/datasource-min.js"></script>

    <script type="text/javascript" src="js/build/swf/swf-min.js"></script>

    <script type="text/javascript" src="js/build/charts/charts-min.js"></script>

    <script type='text/javascript' src='js/build/yahoo-dom-event/yahoo-dom-event.js'></script>

    <script type="text/javascript" src="js/base.js"></script>

    <script type="text/javascript">
        function ddlChange(obj)
        {
            if(obj.value !="Area")
            {
                area.style["display"]= "none";
            }
            else
            {
                area.style["display"]= "block";
            }
            if(obj.value == "")
            {
                $("<%= this.ddlUser.ClientID %>").value = "0";
            }
        }
    </script>

    <script type="text/javascript">
        YAHOO.util.Event.onContentReady("area",function(){
            var ddl = YAHOO.util.Dom.get("<%= this.ddltype.ClientID %>");
            ddlChange(ddl);
        });        
    </script>

    <div id="content">
        <div id="left">
            <div class="leftTitle">
                客户分析</div>
            <ul class="list">
                <li><a href="Report.aspx?type=1">客户来源</a></li>
                <li><a href="Report.aspx?type=2">客户状态</a></li>
                <li><a href="Report.aspx?type=3">客户类型</a></li>
                <li><a href="Report.aspx?type=4">行业</a></li>
                <li><a href="Report.aspx?type=5">地区</a></li>
                <li><a href="Report.aspx?type=6">客户发展月趋势图</a></li>
            </ul>
        </div>
        <div id="right">
            <h4>
                客户分析
            </h4>
            <div>
                <table style="width: 100%; border: 0px;" class="inputTable">
                    <tr>
                        <th style="width: 15%; min-width: 40px;">
                            分析项目:
                        </th>
                        <td style="width: 15%">
                            <%--对于ddltype的listitem的value值是和一个枚举一一对应，方便转换--%>
                            <asp:DropDownList ID="ddltype" runat="server" onchange="ddlChange(this)">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 45%">
                            <div id="area" style="display: none;">
                                <uc1:Area ID="Area1" runat="server" />
                            </div>
                        </td>
                        <td style="width: 15%">
                            <asp:DropDownList ID="ddlUser" runat="server" DataTextField="CnName" DataValueField="UserId">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 10%">
                            <asp:Button ID="btnAnalyse" runat="server" OnClick="btnAnalyse_Click" Text="查询" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="chart">
            </div>
        </div>
    </div>
    <%= this.ClientJscript %>
</asp:Content>
