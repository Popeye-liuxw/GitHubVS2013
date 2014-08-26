<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerCombine.aspx.cs"
    Inherits="EAPP.CRM.Web.CustomerCombine" MasterPageFile="~/MainTemplate.Master" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script type="text/javascript" src="js/base.js"></script>

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="/JS/MyArea.js"></script>

    <script type="text/javascript">
    
        function GetUserDataOrDeptData(val)
        {
            var result = EAPP.CRM.Web.CustomerCombine.GetUserDataOrDeptData(val).value;
            
            var ddl = $("ddlAssignObject");
            
            ddl.length = 0;
            
            if (val == 'user')
            {
                $("<%= this.rbtnUser.ClientID %>").checked = "checked";
                for (var i=0; i < result.Rows.length; i++)  
                {
                    ddl.options.add(new Option(result.Rows[i].CnName,result.Rows[i].UserId));
                }
            }
            else if (val == 'dept')
            {
                $("<%= this.rbtnDept.ClientID %>").checked = "checked";
                for(var k=0; k < result.Rows.length; k++)  
                {
                    ddl.options.add(new Option(result.Rows[k].DeptName,result.Rows[k].DeptId));
                }
            }
        }
        
        function update()
        {
            var ddl = $("ddlAssignObject");
            $("<%= this.AssignObjectId.ClientID %>").value = ddl.value;
        }
        
        function changetxt(txtId,hdId,assign)
        {
            if(!assign)
                $(txtId).value = $(hdId).value;
            else    
            {
                var a = $(hdId).value;
                var arr = a.split(",");
                GetUserDataOrDeptData(arr[0]);
                var ddl = $("ddlAssignObject");
                ddl.value = arr[1];                 
                $("<%= this.AssignObjectId.ClientID %>").value = arr[1];
            }
        }
        
        function selchange(obj)
        {
            $("<%= this.txtSource.ClientID%>").value = obj.options[obj.selectedIndex].text ;
        }
        
        function txtchange()
        {
            $("<%= this.ddlSource.ClientID %>").value = 0;
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
                    <h4>
                        客户合并
                    </h4>
                    <table style="border: 0px; width: 100%" class="inputTable">
                        <tr>
                            <th style="width: 10%; max-width: 30px">
                                字段名
                            </th>
                            <td style="width: 5%; max-width: 30px">
                                保留
                            </td>
                            <td style="width: 22%">
                                客户数据(1)
                            </td>
                            <td style="width: 5%; max-width: 30px">
                                保留
                            </td>
                            <td style="width: 22%">
                                客户数据(2)
                            </td>
                            <td style="width: 36%">
                                合并结果
                            </td>
                        </tr>
                        <tr>
                            <th>
                                客户名称
                            </th>
                            <td>
                                <input type="radio" id="Radio36" name="rName" checked="checked" onclick="changetxt('<%= this.txtName.ClientID %>','<%= this.hdName1.ClientID %>')" />
                                <input id="hdName1" type="hidden" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="lName1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio1" name="rName" onclick="changetxt('<%= this.txtName.ClientID %>','<%= this.hdName2.ClientID %>')" />
                                <input id="hdName2" type="hidden" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="slName2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="必填."></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                客户类型
                            </th>
                            <td>
                                <input type="radio" id="Radio4" name="rType" checked="checked" onclick="changetxt('<%= this.ddlType.ClientID %>','<%= this.hdType1.ClientID %>')" />
                                <input id="hdType1" type="hidden" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="lType1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio5" name="rType" onclick="changetxt('<%= this.ddlType.ClientID %>','<%= this.hdType2.ClientID %>')" />
                                <input id="hdType2" type="hidden" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="slType2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" DataTextField="TypeName" DataValueField="TypeId">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="必选." ControlToValidate="ddlType"
                                    ClientValidationFunction="checkDll" Display="Dynamic"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                主营行业
                            </th>
                            <td>
                                <input type="radio" id="Radio2" name="rTrade" checked="checked" onclick="changetxt('<%= this.ddlTrade.ClientID %>','<%= this.hdTrade1.ClientID %>')" />
                                <input id="hdTrade1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lTrade1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio3" name="rTrade" onclick="changetxt('<%= this.ddlTrade.ClientID %>','<%= this.hdTrade2.ClientID %>')" />
                                <input id="hdTrade2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slTrade2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTrade" runat="server" DataTextField="TradeName" DataValueField="TradeId">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="必选." ControlToValidate="ddlTrade"
                                    ClientValidationFunction="checkDll" Display="Dynamic"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                客户状态
                            </th>
                            <td>
                                <input type="radio" id="Radio6" name="rState" checked="checked" onclick="changetxt('<%= this.slState2.ClientID %>','<%= this.hdState1.ClientID %>')" />
                                <input id="hdState1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lState1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio7" name="b" onclick="changetxt('<%= this.slState2.ClientID %>','<%= this.hdState2.ClientID %>')" />
                                <input id="hdState2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slState2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server" DataTextField="Name" DataValueField="StateId">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                客户来源
                            </th>
                            <td>
                                <input type="radio" id="Radio8" name="rSource" checked="checked" onclick="changetxt('<%= this.ddlSource.ClientID %>','<%= this.hdSource1.ClientID %>')" />
                                <input id="hdSource1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lSource1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio9" name="rSource" onclick="changetxt('<%= this.ddlSource.ClientID %>','<%= this.hdSource2.ClientID %>')" />
                                <input id="hdSource2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slSource2" runat="server"></asp:Literal>
                            </td>
                            <td>                                
                                <asp:DropDownList ID="ddlSource" runat="server" DataTextField="Source" DataValueField="SourceId"
                                    onchange="selchange(this);">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtSource" runat="server" onchange="txtchange"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                员工数量
                            </th>
                            <td>
                                <input type="radio" id="Radio10" name="rEmptotal" checked="checked" onclick="changetxt('<%= this.txtEmpTotal.ClientID %>','<%= this.hdEmpTotal1.ClientID %>')" />
                                <input id="hdEmpTotal1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lEmptotal1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio11" name="rEmptotal" onclick="changetxt('<%= this.txtEmpTotal.ClientID %>','<%= this.hdEmpTotal2.ClientID %>')" />
                                <input id="hdEmpTotal2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slEmptotal2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpTotal" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                年收入
                            </th>
                            <td>
                                <input type="radio" id="Radio12" name="rYear" checked="checked" onclick="changetxt('<%= this.txtYear.ClientID %>','<%= this.hdYear1.ClientID %>')" />
                                <input id="hdYear1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lyear1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio13" name="rYear" onclick="changetxt('<%= this.txtYear.ClientID %>','<%= this.hdYear2.ClientID %>')" />
                                <input id="hdYear2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slyear2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                详细地址
                            </th>
                            <td>
                                <input type="radio" id="Radio14" name="rAddress" checked="checked" onclick="changetxt('<%= this.txtAddress.ClientID %>','<%= this.hdAddress1.ClientID %>')" />
                                <input id="hdAddress1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lAddress1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio15" name="rAddress" onclick="changetxt('<%= this.txtAddress.ClientID %>','<%= this.hdAddress2.ClientID %>')" />
                                <input id="hdAddress2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slAddress2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                邮政编码
                            </th>
                            <td>
                                <input type="radio" id="Radio16" name="rPostCode" checked="checked" onclick="changetxt('<%= this.txtPostCode.ClientID %>','<%= this.hdPostCode1.ClientID %>')" />
                                <input id="hdPostCode1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lPostCode1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio17" name="rPostCode" onclick="changetxt('<%= this.txtPostCode.ClientID %>','<%= this.hdPostCode2.ClientID %>')" />
                                <input id="hdPostCode2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slPostCode2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtPostCode" Display="Dynamic" ErrorMessage="格式错误." 
                                    ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                电子邮件
                            </th>
                            <td>
                                <input type="radio" id="Radio18" name="rEmail" checked="checked" onclick="changetxt('<%= this.txtEmail.ClientID %>','<%= this.hdEmail1.ClientID %>')" />
                                <input id="hdEmail1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lEmail1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio19" name="rEmail" onclick="changetxt('<%= this.txtEmail.ClientID %>','<%= this.hdEmail2.ClientID %>')" />
                                <input id="hdEmail2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slEmail2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="格式错误." 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                电话
                            </th>
                            <td>
                                <input type="radio" id="Radio20" name="rTel" checked="checked" onclick="changetxt('<%= this.txtTel.ClientID %>','<%= this.hdTel1.ClientID %>')" />
                                <input id="hdTel1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lTel1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio21" name="rTel" onclick="changetxt('<%= this.txtTel.ClientID %>','<%= this.hdTel2.ClientID %>')" />
                                <input id="hdTel2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slTel2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                                Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                传真
                            </th>
                            <td>
                                <input type="radio" id="Radio22" name="rFax" checked="checked" onclick="changetxt('<%= this.txtFax.ClientID %>','<%= this.hdFax1.ClientID %>')" />
                                <input id="hdFax1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lFax1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio23" name="rFax" onclick="changetxt('<%= this.txtFax.ClientID %>','<%= this.hdFax2.ClientID %>')" />
                                <input id="hdFax2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slFax2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFax"
                                Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                手机
                            </th>
                            <td>
                                <input type="radio" id="Radio24" name="rMobile" checked="checked" onclick="changetxt('<%= this.txtMobile.ClientID %>','<%= this.hdMobile1.ClientID %>')" />
                                <input id="hdMobile1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lMobile1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio25" name="rMobile" onclick="changetxt('<%= this.txtMobile.ClientID %>','<%= this.hdMobile2.ClientID %>')" />
                                <input id="hdMobile2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slMobile2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMobile"
                                Display="Dynamic" ErrorMessage="格式错误." ValidationExpression="(13[0-9]|15[0|1|2|3|6|7|8|9]|18[8|9])\d{8}"></asp:RegularExpressionValidator>
                       
                            </td>
                        </tr>
                        <tr>
                            <th>
                                主页
                            </th>
                            <td>
                                <input type="radio" id="Radio26" name="rHomePage" checked="checked" onclick="changetxt('<%= this.txtHomePage.ClientID %>','<%= this.hdHomePage1.ClientID %>')" />
                                <input id="hdHomePage1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lHomePage1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio27" name="rHomePage" onclick="changetxt('<%= this.txtHomePage.ClientID %>','<%= this.hdHomePage2.ClientID %>')" />
                                <input id="hdHomePage2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slHomePage2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHomePage" runat="server"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtHomePage"
                            Display="Dynamic" ErrorMessage="格式错误." ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                 
                            </td>
                        </tr>
                        <tr>
                            <th>
                                地区
                            </th>
                            <td>
                                <input type="radio" id="Radio28" name="rArea" checked="checked" onclick="changetxt1('<%= this.hdArea1.ClientID %>')" />
                                <input id="hdArea1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lArea1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio29" name="rArea" onclick="changetxt1('<%= this.hdArea2.ClientID %>')" />
                                <input id="hdArea2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slArea2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <div id="area">
                                </div>

                                <script type="text/javascript">
                                    function changetxt1(obj)
                                    {
                                        area.innerHTML="";                                        
                                        var xx = new MyArea($("area"),$("<%= this.result.ClientID %>"),$(obj).value);
                                        xx.init();
                                        $("<%= this.result.ClientID %>").value = $(obj).value;
                                    }
                                    function GetDataTable(val)
                                    {
                                        return result = EAPP.CRM.Web.CustomerCombine.GetCityData(val).value;
                                    }    
                                    
                                    function GetData(val)
                                    {
                                        return result = EAPP.CRM.Web.CustomerCombine.GetCity(val).value;
                                    }
                                    YAHOO.util.Event.onDOMReady(function(){                                                                                
                                        $('Radio28').fireEvent("onclick");
                                    });
                                </script>

                                <input id="result" name="result" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                备注
                            </th>
                            <td>
                                <input type="radio" id="Radio30" name="rRemark" checked="checked" onclick="changetxt('<%= this.txtRemark.ClientID %>','<%= this.hdRemark1.ClientID %>')" />
                                <input id="hdRemark1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lRemark1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio31" name="rRemark" onclick="changetxt('<%= this.txtRemark.ClientID %>','<%= this.hdRemark2.ClientID %>')" />
                                <input id="hdRemark2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slRemark2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                负责人
                            </th>
                            <td>
                                <input type="radio" id="Radio32" name="rAssignObject" checked="checked" onclick="changetxt('<%= this.rbtnDept.ClientID %>','<%= this.hdAssignObject1.ClientID %>','b')" />
                                <input id="hdAssignObject1" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="lAssignObj1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="radio" id="Radio33" name="rAssignObject" onclick="changetxt('<%= this.rbtnUser.ClientID %>','<%= this.hdAssignObject2.ClientID %>','a')" />
                                <input id="hdAssignObject2" runat="server" type="hidden" />
                            </td>
                            <td>
                                <asp:Literal ID="slAssignObj2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <input type="hidden" name="AssignObjectId" id="AssignObjectId" runat="server" />
                                <input type="radio" name="assignObject" runat="server" id="rbtnUser" value="user"
                                    onclick="GetUserDataOrDeptData('user')" />用户
                                <input type="radio" name="assignObject" runat="server" id="rbtnDept" value="dept"
                                    onclick="GetUserDataOrDeptData('dept')" />部门
                                <select id="ddlAssignObject" name="ddlAssignObject" onchange="update()">
                                </select>
                            </td>
                        </tr>
                    </table>
                    <div class="actionArea">
                        <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="bigBtn" OnClick="btnOk_Click" />
                        <input id="Reset1" type="reset" value="重置" class="bigBtn" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>

    <script type="text/javascript">
        YAHOO.util.Event.onDOMReady(function(){
            var type = "user";
            if ($("<%= this.rbtnDept.ClientID %>").checked)
                type = "dept";
            GetUserDataOrDeptData(type);
            update();
        });
    </script>

</asp:Content>
