<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Popedom.aspx.cs" Inherits="EAPP.CRM.Web.Popedom"
    MasterPageFile="~/MainTemplate.Master" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script type="text/javascript" src="js/base.js"></script>

    <script type="text/javascript">
        function ckAll(obj,id)
        {
            var inputs = $(id).getElementsByTagName("input");            
            for(var i = 0; i < inputs.length; i++)
            {
                if(inputs[i].type == "checkbox")
                {
                    inputs[i].checked = obj.checked;
                }
            }
        }
    </script>

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
                权限设置
            </h4>
            <asp:Panel ID="pnlRole1" runat="server">            
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:Panel ID="pnlRole" runat="server">
                        <table style="width: 100%; border: 0px;">
                            <tr>
                                <td valign="middle" align="center" style="width: 170px">
                                    角色:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRoleName" runat="server" ReadOnly="true"></asp:TextBox>
                                    <input id="hdRoleId" type="hidden" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" align="center" style="width: 170px">
                                    <input id="ckCustomer" type="checkbox" onclick="ckAll(this,'customer')" />客户管理
                                </td>
                                <td id="customer" valign="top" align="left">
                                    <table style="width: 100%; border: 0; margin: 0px">
                                        <tr>
                                            <td>
                                                <input id="ckCustomerAdd" type="checkbox" runat="server" value="CustomerAdd" />新增客户
                                                <input id="ckCustomerEdit" type="checkbox" runat="server" value="CustomerEdit" />编辑客户
                                                <input id="ckCustomerShare" type="checkbox" runat="server" value="CustomerShare" />客户共享
                                                <input id="ckCustomerDrop" type="checkbox" runat="server" value="CustomerDrop" />放入回收站
                                                <input id="ckCustomerAssign" type="checkbox" runat="server" value="CustomerAssign" />分配
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left" style="width: 100%">
                                                <input id="ckCustomerDelete" type="checkbox" runat="server" value="CustomerDelete" />彻底删除
                                                <input id="ckCustomerCombine" type="checkbox" runat="server" value="CustomerCombine" />客户合并
                                                <%--<input id="ckCustomerImport" type="checkbox" runat="server" value="CustomerImport" />导入资料--%>
                                                <input id="ckCustomerExport" type="checkbox" runat="server" value="CustomerExport" />导出资料
                                                <input id="ckCustomerSearch" type="checkbox" runat="server" value="CustomerSearch" />客户查询
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" align="center" style="width: 170px">
                                    <input id="ckSystem" type="checkbox" onclick="ckAll(this,'system')" />系统管理
                                </td>
                                <td valign="top" align="left" id="system">
                                    <table style="width: 100%; border: 0; margin: 0px">
                                        <tr>
                                            <td>
                                                <input id="ckSMTPConfig" type="checkbox" runat="server" value="SMTPConfig" />SMTP配置
                                                <input id="ckRole" type="checkbox" runat="server" value="Role" />角色与权限
                                                <input id="ckBaseDataManage" type="checkbox" runat="server" value="BaseDataManage" />基础数据维护
                                                <%--<input id="ckSystemRestore" type="checkbox" runat="server" value="SystemRestore" />系统恢复
                                                <input id="ckBackupDatabase" type="checkbox" runat="server" value="BaupDatabase" />备份数据库
                                                <input id="ckRestoreDatabase" type="checkbox" runat="server" value="RestoreDatabase" />恢复数据库--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" align="center" style="width: 170px">
                                    <input id="Checkbox1" type="checkbox" onclick="ckAll(this,'report')" />统计分析
                                </td>
                                <td valign="top" align="left" id="report">
                                    <table style="width: 100%; border: 0; margin: 0px">
                                        <tr>
                                            <td>
                                                <input id="ckGlobalAnalysis" type="checkbox" runat="server" value="GlobalAnalysis" />全局分析
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" align="center" style="width: 170px">
                                    <input id="ckUser" type="checkbox" onclick="ckAll(this,'user')" />用户管理
                                </td>
                                <td valign="top" align="left" id="user">
                                    <table style="width: 100%; border: 0; margin: 0px">
                                        <tr>
                                            <td>
                                                <input id="ckUserView" type="checkbox" runat="server" value="UserView" />查看
                                                <input id="ckUserAdd" type="checkbox" runat="server" value="UserAdd" />新增
                                                <input id="ckUserEdit" type="checkbox" runat="server" value="UserEdit" />编辑
                                                <input id="ckUserDelete" type="checkbox" runat="server" value="UserDelete" />删除
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="bigBtn" OnClick="btnOk_Click" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:View>
            </asp:MultiView>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
