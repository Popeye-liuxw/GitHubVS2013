<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartArea.aspx.cs" Inherits="EAPP.CRM.Web.PartArea" %>

<html>
<head>
    <title></title>
    <link type="text/css" rel="Stylesheet" href="CSS/main.css" />
</head>
<body>
    <form id="form2" runat="server">
    <div id="right" style="width:630px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AreaId"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" Width="100%"
            CssClass="gridview">
            <Columns>
                <asp:TemplateField HeaderText="类型名称">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AreaName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("AreaName") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("AreaId") %>'
                            CommandName="Update">更新</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("AreaId") %>'
                            CommandName="Cancel">取消</asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("AreaId") %>'
                            CommandName="Edit">编辑</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("AreaId") %>'
                            CommandName="Delete" OnClientClick="return window.confirm('确定要删除？');">删除</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="97"/>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
