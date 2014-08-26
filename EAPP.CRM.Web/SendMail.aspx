<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="EAPP.CRM.Web.SendMail"
    MasterPageFile="~/MainTemplate.Master" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script src="js/base.js" type="text/javascript"></script>

    <script type="text/javascript">
    function addEmailContacts(obj)
    {   
        var conid = obj.split("_")[1];        
        var txtTo =  $("<%= this.txtTo.ClientID %>");
        var hd = $("hd");
        var hdids =  hd.value;
        var mailAddress = getAddress(conid,hdids);
        hd.value = mailAddress[0];
        txtTo.value += mailAddress[1];
    }
    
    function getAddress(conid,obj)
    {
        return EAPP.CRM.Web.SendMail.getAddress(conid,obj).value;
    }
    </script>

    <input id="hd" type="hidden" />
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
        <div id="right" style="width: 785px;">
            <h4>
                发送邮件</h4>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table id="sendMail" class="sendmail">
                        <tr>
                            <td>
                                <div id="mailto">
                                    <table class="inputTable" style="width: 100%; border: 0px">
                                        <tr>
                                            <th style="width: 10%; min-width: 30px">
                                                收件人:
                                            </th>
                                            <td style="width: 90%">
                                                <asp:TextBox ID="txtTo" runat="server" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="mailsubject">
                                    <table class="inputTable" style="width: 100%; border: 0px">
                                        <tr>
                                            <th style="width: 10%; min-width: 30px">
                                                主题:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSubject" runat="server" Width="98%"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="mailcontent">
                                    <table class="inputTable" style="width: 100%; border: 0px">
                                        <tr>
                                            <th style="width: 10%; min-width: 30px">
                                                内容:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="98%" Rows="12"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="contact">
                                 <div class="tit">
                                    联系人
                                </div>
                                <div id="conlst" style="height: 250px; overflow: auto;">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <div class="" style="padding-left: 10px;  line-height: 20px">
                                                <a id='<%# "emailId_" + Eval("ContactId") %>' href="javascript:void(0)" onclick="addEmailContacts('<%# "emailId_" + Eval("ContactId") %>');return false;"
                                                    title='<%# Eval("Email1") %>'>
                                                    <%# Eval("CnName")%></a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </td>
                        </tr>
                    </table>
                  
                    <div class="actionArea">
                        <asp:Button ID="btnSend" runat="server" Text="发送" CssClass="bigBtn" OnClick="btnSend_Click" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblSucMessage" runat="server" Text="发送成功"></asp:Label>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SendMail.aspx" Text="继续发送"></asp:HyperLink>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:Label ID="lblErrMessage" runat="server"></asp:Label>
                    <a href="javascript:void(0);" onclick="JavaScript:history.go(-1);">返回</a>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
