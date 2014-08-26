<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchContact.aspx.cs"
    Inherits="EAPP.CRM.Web.SearchContact" MasterPageFile="~/MainTemplate.Master" %>

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
            <div>
                <h4>
                    查询</h4>
                <table style="width: 100%; border: 0px" class="inputTable">
                    <tr>
                        <th style="width: 10%">
                            姓名:
                        </th>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                        </td>
                        <th style="width: 10%">
                            客户名称:
                        </th>
                        <td style="width: 40%">
                            <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            电话:
                        </th>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTel"
                                Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                        </td>
                        <th>
                            电子邮件:
                        </th>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                Display="Dynamic" ErrorMessage="邮件格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            主营行业:
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlTrade" runat="server" DataTextField="TradeName" DataValueField="TradeId">
                            </asp:DropDownList>
                        </td>
                        <th>
                            客户状态:
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlState" runat="server" DataTextField="Name" DataValueField="StateId">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="actionArea">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn" OnClick="btnSearch_Click" />
                    <input type="reset" id="reset" name="reset" value="重置" class="btn" />
                </div>
            </div>
            <div id="right_bottom">
                <asp:GridView ID="gvlist" runat="server" AllowPaging="True" DataKeyNames="ContactId"
                    CssClass="gridview" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="gvlist_PageIndexChanging"
                    PageSize="20">
                    <PagerSettings Position="TopAndBottom" />
                    <Columns>
                        <asp:TemplateField HeaderText="联系人">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("CnName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Post" HeaderText="职务" />
                        <asp:BoundField DataField="MobilePhone" HeaderText="手机" />
                        <asp:BoundField DataField="Tel" HeaderText="座机" />
                        <asp:BoundField DataField="Fax" HeaderText="传真" />
                        <asp:BoundField DataField="Email1" HeaderText="电子邮件" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# "EditContacts.aspx?contactid=" + Eval("ContactId") %>'>编辑</asp:HyperLink>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("ContactId") %>'
                                                Text="删除" OnClientClick="return window.confirm('确定要删除？');" OnClick="btnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <PagerTemplate>
                        第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>页
                        共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount  %>"></asp:Label>页
                        <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page">首页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                            CommandName="Page">上一页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page">下一页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page">尾页</asp:LinkButton>
                    </PagerTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
