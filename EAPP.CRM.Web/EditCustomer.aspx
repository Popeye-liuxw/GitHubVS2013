<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="EAPP.CRM.Web.EditCustomer"
    MasterPageFile="~/MainTemplate.Master" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script type="text/javascript" src="JS/base.js"></script>

    <link rel="stylesheet" type="text/css" href="js/build/calendar/assets/skins/sam/calendar.css" />

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="js/build/calendar/calendar-min.js"></script>

    <script type="text/javascript">        
        
        function selchange(obj)
        {
            $("<%= this.txtSource.ClientID%>").value = obj.options[obj.selectedIndex].text ;
        }
        
        function txtchange()
        {
            $("<%= this.ddlSource.ClientID %>").value = 0;
        }
        
    </script>
<%-- 
    <script type="text/javascript">
     function GetUserDataOrDeptData(val)
        {
            var result = EAPP.CRM.Web.EditCustomer.GetUserDataOrDeptData(val).value;
            var ddl = $("<%= this.ddlAssignObject.ClientID%>");
            
            ddl.length = 0;
            
            if(val=='user')
            {
                for(var i=0; i < result.Rows.length; i++)  
                {
                    ddl.options.add(new Option(result.Rows[i].CnName,result.Rows[i].UserId));
                }
            }
            else if(val=='dept')
            {
                for(var k=0; k < result.Rows.length; k++)  
                {
                    ddl.options.add(new Option(result.Rows[k].DeptName,result.Rows[k].DeptId));
                }
            }
        }
        
        function update()
        {
            var ddl = $("<%= this.ddlAssignObject.ClientID %>");
            $("<%= this.AssignObjectId.ClientID %>").value = ddl.value;
        }
        
        YAHOO.util.Event.onDOMReady(function(){
            update();
        });
    </script>
--%>
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
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <h4>
                        编辑客户资料</h4>
                    <table border="0" class="inputTable">
                        <tr>
                            <th>
                                客户名称:
                            </th>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="*请填写客户名称"></asp:RequiredFieldValidator>
                            </td>
                            <th>
                                客户分类:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" DataTextField="TypeName" DataValueField="TypeId">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                客户来源:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlSource" runat="server" DataTextField="Source" DataValueField="SourceId"
                                    onchange="selchange(this);">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSource" runat="server" onchange="txtchange();"></asp:TextBox>
                            </td>
                            <th>
                                客户状态:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server" DataTextField="Name" DataValueField="StateId">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                客户行业:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlTrade" runat="server" DataTextField="TradeName" DataValueField="TradeId">
                                </asp:DropDownList>
                            </td>
                            <th>
                            </th>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                年收入:
                            </th>
                            <td>
                                <asp:TextBox ID="txtYearRevenue" runat="server"></asp:TextBox>
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
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="*请输入正确的电子邮件" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                电话:
                            </th>
                            <td>
                                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                                    Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                传真:
                            </th>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFax"
                                    Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                手机:
                            </th>
                            <td>
                                <asp:TextBox ID="txtMobilePhone" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMobilePhone"
                                    Display="Dynamic" ErrorMessage="*请输入正确的手机号码" ValidationExpression="(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                地区:
                            </th>
                            <td>
                                <uc1:Area ID="Area1" runat="server" />
                            </td>
                            <th>
                                详细地址:
                            </th>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                邮编:
                            </th>
                            <td>
                                <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostCode"
                                    Display="Dynamic" ErrorMessage="*请输入正确的邮编" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                            </td>
                            <th>
                                主页:
                            </th>
                            <td>
                                <asp:TextBox ID="txtHomePage" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtHomePage"
                                    Display="Dynamic" ErrorMessage="*请输入正确的主页" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                     <%--   <tr>
                            <th>
                                负责对象:
                            </th>
                            <td>
                                <input runat="server" type="radio" name="assignObject" id="rbtnUser" value="user"
                                    onclick="GetUserDataOrDeptData('user')" />用户
                                <input runat="server" type="radio" name="assignObject" id="rbtnDept" value="dept"
                                    onclick="GetUserDataOrDeptData('dept')" />部门
                                <select id="ddlAssignObject" name="ddlAssignObject" runat="server" onchange="update()">
                                </select>
                                <input type="hidden" name="AssignObjectId" id="AssignObjectId" runat="server" />
                            </td>
                            <th>
                                负责日期:
                            </th>
                            <td>
                                <input type="text" id="date" name="date" value="" runat="server" />
                                <button type="button" id="show" title="Show Calendar" onclick="selectData($('<%= this.date.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="18" alt="Calendar" /></button>
                            </td>
                        </tr>--%>
                        <tr>
                            <th>
                                备注:
                            </th>
                            <td colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="3" Columns="80"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="bigBtn" />
                        <input type="reset" id="btnReset" value="重置" class="bigBtn" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    参数错误。
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
