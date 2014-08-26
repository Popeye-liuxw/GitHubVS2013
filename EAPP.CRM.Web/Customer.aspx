<%@ Page Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true"
    CodeBehind="Customer.aspx.cs" Inherits="EAPP.CRM.Web.Customer" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script type="text/javascript" src="JS/dialog.js"></script>

    <script type="text/javascript">
        function assignCustomer()
        {
            openWindow('Assigning.aspx?ids=<%= Request.QueryString["cid"] %>&rnd='+Math.random(),"250","100");
            return false;
        }
    </script>

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
                    <div id="right_top">
                        <asp:Button ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" CssClass="btn" />
                        <asp:Button ID="btnCopy" runat="server" Text="复制" OnClick="btnCopy_Click" CssClass="btn" />
                        <input type="button" id="btnAssign" name="btnAssign" value="分配" onclick="return assignCustomer();"
                            class="btn" runat="server" /><asp:Button ID="btnShare" runat="server" Text="共享" OnClick="btnShare_Click"
                                CssClass="btn" />
                        <asp:Button ID="btnRecycle" runat="server" Text="放入回收站" OnClick="btnRecycle_Click"
                            CssClass="btn" />
                        <asp:Button ID="btnSearchCustomer" runat="server" Text="客户通" OnClick="btnSearchCustomer_Click"
                            CssClass="btn" />
                        <asp:Button ID="btnPrint" runat="server" Text="打印" CssClass="btn" Visible="False" />
                    </div>
                    <div>
                        <h4>
                            客户信息</h4>
                        <table border="0" width="100%" class="inputTable">
                            <tr>
                                <th width="10%">
                                    客户名称:
                                </th>
                                <td width="40%">
                                    <asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                                <th width="10%">
                                    客户分类:
                                </th>
                                <td width="40%">
                                    <asp:TextBox ID="txtType" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    客户来源:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtSource" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    客户状态:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtState" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    客户行业:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtTrade" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    地区:
                                </th>
                                <td>
                                    <uc1:Area ID="txtArea" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    年收入:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtYearRevenue" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    员工人数:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtEmployeeTotal" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    电子邮件:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    电话:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtTel" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    传真:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtFax" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    手机:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMobilePhone" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    邮编:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPostCode" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                                <th>
                                    主页:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtHomePage" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    详细地址:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Columns="80" Rows="2"
                                        ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    备注:
                                </th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div id="contactInfo">
                            <h4>
                                联系人</h4>
                            <a href='AddContacts.aspx?cid=<%= Request.QueryString["cid"] %>' target="_self">添加</a>
                            <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" DataKeyNames="ContactId"
                                Width="100%" CssClass="gridview" AllowPaging="True" OnPageIndexChanging="gvContacts_PageIndexChanging"
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
                                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%# "EditContacts.aspx?contactid=" + Eval("ContactId") %>'>编辑</asp:HyperLink>
                                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("ContactId") %>'
                                                Text="删除" OnClientClick="return window.confirm('确定要删除？');" OnClick="btnDelete_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <PagerTemplate>
                                    第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"></asp:Label>页
                                    共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>页
                                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page">首页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                        CommandName="Page">上一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page">下一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page">尾页</asp:LinkButton>
                                </PagerTemplate>
                            </asp:GridView>
                        </div>
                        <div id="fllow">
                            <h4>
                                跟进记录</h4>
                            <a href="AddFllowUpPlan.aspx?cid=<%= Request.QueryString["cid"] %>" target="_self">添加</a>
                            <asp:GridView ID="gvFollowUpPlan" runat="server" AutoGenerateColumns="False" DataKeyNames="PlanId"
                                Width="100%" CssClass="gridview" OnPageIndexChanging="gvFollowUpPlan_PageIndexChanging"
                                AllowPaging="True" PageSize="20">
                                <PagerSettings Position="TopAndBottom" />
                                <Columns>
                                    <asp:BoundField DataField="ContactTime" HeaderText="联系时间" />
                                    <asp:TemplateField HeaderText="联系人">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# GetContactsName(Eval("ContactId").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# GetState(Eval("PlanState").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="跟进后客户成熟度">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# GetCustomerState(Eval("CustomerStateId").ToString()) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Result" HeaderText="跟进结果" />
                                    <asp:BoundField DataField="NextTime" HeaderText="下次跟进时间" />
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# "EditFllowUpPlan.aspx?fpid=" + Eval("PlanId") %>'>编辑</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <PagerTemplate>
                                    第<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>"></asp:Label>页
                                    共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>"></asp:Label>页
                                    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page">首页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                        CommandName="Page">上一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page">下一页</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page">尾页</asp:LinkButton>
                                </PagerTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
