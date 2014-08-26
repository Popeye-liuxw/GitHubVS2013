<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="EAPP.CRM.Web.User"
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
                用户列表
            </h4>
            <asp:Panel ID="newuser" runat="server">
                <h4>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddUser.aspx">添加用户</asp:HyperLink>
                </h4>
            </asp:Panel>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="gridview" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="UserId">
                <Columns>
                    <asp:TemplateField HeaderText="登陆名">
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("LoginName") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Status").ToString() == "0"?"无效":"有效" %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="中文名">
                        <ItemTemplate>
                            <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("CnName") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="英文名">
                        <ItemTemplate>
                            <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("EnName") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="职位">
                        <ItemTemplate>
                            <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Post") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="工作电话">
                        <ItemTemplate>
                            <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("WorkPhone") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="手机">
                        <ItemTemplate>
                            <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("MobilePhone") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="电子邮件">
                        <ItemTemplate>
                            <asp:Literal ID="Literal8" runat="server" Text='<%# Eval("Email1") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "EditUser.aspx?uid="+Eval("UserId")%>'
                                Visible='<%# (this.HasPopedom("UserEdit") && !("Admin".Equals(Eval("LoginName").ToString()))) %>'>编辑</asp:HyperLink>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CommandArgument='<%# Eval("UserId") %>'
                                Visible='<%# (this.HasPopedom("UserEdit") && !("Admin".Equals(Eval("LoginName").ToString()))) %>'
                                OnClientClick="return window.confirm('确定要删除该用户？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
