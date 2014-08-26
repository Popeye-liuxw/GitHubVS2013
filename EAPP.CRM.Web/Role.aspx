<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="EAPP.CRM.Web.Role"
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
                新增角色</h4>
            <div id="insert">
                <table  class="tinfo">
                    <tr>
                        <th style="width: 10%; min-width: 30px">
                            角色名称:
                        </th>
                        <td style="width: 20%;">
                            <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                        </td>
                        <th style="width: 10%; min-width: 30px">
                            备注:
                        </th>
                        <td style="width: 40%;">
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="2" Columns="30"></asp:TextBox>
                        </td>
                        <td style="width: 10%; min-width: 30px">
                            <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" Style="height: 26px" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                Width="100%" DataKeyNames="RoleId" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="角色名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("RoleName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("RoleName") %>'></asp:Literal>
                        </ItemTemplate>
                        <ItemStyle Width="200" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Columns="30" Text='<%# Eval("Remark") %>'
                                TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Remark") %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" CommandArgument='<%# Eval("RoleId") %>'>更新</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" CommandArgument='<%# Eval("RoleId") %>'
                                Visible='<%# !("系统管理员".Equals(Eval("RoleName").ToString())) %>'>编辑</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="return window.confirm('确定要删除');"
                                CommandArgument='<%# Eval("RoleId") %>' Visible='<%# !("系统管理员".Equals(Eval("RoleName").ToString())) %>'>删除</asp:LinkButton>
                            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Popedom.aspx?rid="+Eval("RoleId")%>'
                                Visible='<%# !("系统管理员".Equals(Eval("RoleName").ToString())) %>'>权限设置</asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="120" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
