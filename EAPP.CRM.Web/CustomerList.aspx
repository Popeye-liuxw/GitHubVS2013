<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainTemplate.Master"
    CodeBehind="CustomerList.aspx.cs" Inherits="EAPP.CRM.Web.CustomerList" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script type="text/javascript" src="JS/base.js"></script>

    <link rel="stylesheet" type="text/css" href="js/build/calendar/assets/skins/sam/calendar.css" />

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="js/build/calendar/calendar-min.js"></script>

    <script type="text/javascript" src="JS/dialog.js"></script>

    <script type="text/javascript">
        
        function checkall(bflag)
        {
            var inputs = $("right_bottom").getElementsByTagName("input");
            for(var i = 0; i < inputs.length; i++)
            {
                if(inputs[i].type == "checkbox")
                {
                    inputs[i].checked = bflag;                    
                }
            }
        }
        
        function checkValues(msg)
        {
            var flag = false;;
            var inputs = $("right_bottom").getElementsByTagName("input");
            for(var i = 0; i < inputs.length; i++)
            {
                if(inputs[i].type == "checkbox" && inputs[i].checked && inputs[i].name != "ckall")
                {
                    flag = true;
                }
            }
            
            if(!flag)
            {
                window.alert("至少选择一个客户。");
                return false;            
            }
            else
            {            
                var result = window.confirm(msg);
                if (!result) return false;
            }
            
            return true;
        }
        
        function assignCustomer(msg)
        {           
            var flag = false;;
            var inputs = $("right_bottom").getElementsByTagName("input");
            var ids = "";
            for(var i = 0; i < inputs.length; i++)
            {
                if(inputs[i].type == "checkbox" && inputs[i].checked && inputs[i].name != "ckall")
                {
                    flag = true;
                    ids += "," + inputs[i].value;
                }
            }
            
            if(!flag)
            {
                window.alert("至少选择一个客户。"); 
            }
            else
            {            
                openWindow("Assigning.aspx?ids=" + ids+"&rnd="+Math.random(),"250","100");
            }
            
            return false;
        }
        
        function customerCombine()
        {
            var inputs = $("right_bottom").getElementsByTagName("input");
            var selCount = 0;
            var ids = new Array();
            
            for(var i = 0; i < inputs.length; i++)
            {
                if(inputs[i].type == "checkbox" && inputs[i].checked && inputs[i].name != "ckall")
                {   
                    ids[selCount] = inputs[i].value;
                    selCount +=1;
                    if(selCount == 3)
                        break;
                }
            }
            
            if(selCount != 2)
            {
                window.alert("必须选择两个客户。"); 
            }
            else
            {            
                document.location = "/CustomerCombine.aspx?fid=" + ids[0] + "&sid=" + ids[1]+"&rnd="+Math.random();                
            }
            return false;
        }

        function advanceSearch()
        {
            var tab = $('advancetable');
            if(tab.style['display'] != 'block')
            {   
                tab.style['display'] = 'block';
            }
            else
            {
                tab.style['display'] = 'none';
            }
            return false;
        }
    </script>

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
            <asp:Panel ID="plSearch" runat="server">
                <div id="search">
                    <h4>
                        查询</h4>
                    <table border="0" style="width: 100%" class="inputTable">
                        <tr>
                            <th style="width: 15%">
                                客户名称:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                地区:
                            </th>
                            <td style="width: 35%">
                                <uc1:Area ID="Area1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                联系人:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                客户分类:
                            </th>
                            <td style="width: 35%">
                                <asp:DropDownList ID="ddlType" runat="server" DataTextField="TypeName" DataValueField="TypeId">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                主营行业:
                            </th>
                            <td style="width: 35%">
                                <asp:DropDownList ID="ddlTrade" runat="server" DataTextField="TradeName" DataValueField="TradeId">
                                </asp:DropDownList>
                            </td>
                            <th style="width: 15%">
                                状态:
                            </th>
                            <td style="width: 35%">
                                <asp:DropDownList ID="ddlState" runat="server" DataTextField="Name" DataValueField="StateId">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                地址:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            </td>
                            <th style="width: 15%">
                                来源:
                            </th>
                            <td style="width: 35%">
                                <asp:DropDownList ID="ddlSource" runat="server" DataTextField="Source" DataValueField="SourceId">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 15%">
                                电话:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTel"
                                    Display="Dynamic" ErrorMessage="格式如:029-85426781" ValidationExpression="(\d{3}-)?(\d{3,4})-(\d{7,8})(-\d{1,4})?"></asp:RegularExpressionValidator>
                            </td>
                            <th style="width: 15%">
                                手机:
                            </th>
                            <td style="width: 35%">
                                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                    Display="Dynamic" ErrorMessage="手机格式不正确" ValidationExpression="(13[0-9]|15[0|1|2|3|6|7|8|9]|18[8|9])\d{8}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                    <table id="advancetable" border="0" style="width: 100%; display: none;" class="inputTable">
                        <tr>
                            <th style="width: 21%">
                                负责时间:
                            </th>
                            <td style="width: 79%">
                                <input type="text" id="AssignDateStart" name="AssignDateStart" runat="server" readonly="readonly" />
                                <%--<asp:TextBox ID="AssignDateStart" runat="server" ReadOnly="True"></asp:TextBox>--%>
                                <button type="button" id="show" title="Show Calendar" onclick="selectData($('<%= this.AssignDateStart.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>
              
                                到:
        
                                <%--<asp:TextBox ID="AssignDateEnd" runat="server" ReadOnly="True"></asp:TextBox>--%>
                                <input type="text" id="AssignDateEnd" name="AssignDateEnd" runat="server" readonly="readonly" />
                                <button type="button" id="Button5" title="Show Calendar" onclick="selectData($('<%= this.AssignDateEnd.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 21%">
                                最近联系时间:
                            </th>
                            <td style="width: 79%">
                                <%--<asp:TextBox ID="NearTiemStart" runat="server" ReadOnly="True"></asp:TextBox>--%>
                                <input type="text" id="NearTiemStart" name="NearTiemStart" runat="server" readonly="readonly" />
                                <button type="button" id="Button1" title="Show Calendar" onclick="selectData($('<%= this.NearTiemStart.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>

                                到:

                                <%--<asp:TextBox ID="NearTimeEnd" runat="server" ReadOnly="True"></asp:TextBox>--%>
                                <input type="text" id="NearTimeEnd" name="NearTimeEnd" runat="server" readonly="readonly" />
                                <button type="button" id="Button3" title="Show Calendar" onclick="selectData($('<%= this.NearTimeEnd.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 21%">
                                下次联系时间:
                            </th>
                            <td style="width: 79%">
                                <%--<asp:TextBox ID="NextTimeStart" runat="server" ReadOnly="True"></asp:TextBox>--%>
                                <input type="text" id="NextTimeStart" name="NextTimeStart" runat="server" readonly="readonly" />
                                <button type="button" id="Button2" title="Show Calendar" onclick="selectData($('<%= this.NextTimeStart.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>

                                到:

                                <%--<asp:TextBox ID="NextTimeEnd" runat="server" ReadOnly="True"></asp:TextBox>--%>
                                <input type="text" id="NextTimeEnd" name="NextTimeEnd" runat="server" readonly="readonly" />
                                <button type="button" id="Button4" title="Show Calendar" onclick="selectData($('<%= this.NextTimeEnd.ClientID %>'))">
                                    <img src="images/calbtn.gif" width="18" height="16" alt="Calendar" />
                                </button>
                            </td>
                        </tr>
                    </table>
                    <div style="text-align: right;">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" class="btn" />
                        <a href="javascript:void(null);" onclick="return advanceSearch();">高级</a>
                    </div>
                </div>
            </asp:Panel>
            <div id="right_top">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="Viewmycus" runat="server">
                        <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" CssClass="btn" />
                        <asp:Button ID="btnRecycle" runat="server" Text="放入回收站" OnClientClick="return checkValues('确定放入回收站？');"
                            OnClick="ibtnRemove_Click" CssClass="btn" />
                        <asp:Button ID="btnShare" runat="server" Text="共享" OnClientClick="return checkValues('确定要共享用户？');"
                            OnClick="ibtnShare_Click" CssClass="btn" />
                        <input type="button" id="btnAssign" runat="server" value="分配" onclick="return assignCustomer();"
                            class="btn" /><input id="btnCombine" type="button" value="合并" runat="server" onclick="return customerCombine();"
                                class="btn" /><asp:Button ID="btnExport" runat="server" Text="导出客户资料" CssClass="btn"
                                    OnClick="btnExport_Click" />
                        <asp:Button ID="btnImport" runat="server" Text="导入客户资料" CssClass="btn" />
                    </asp:View>
                    <asp:View ID="Viewsharecus" runat="server">
                        <asp:Button ID="btnAdd2" runat="server" Text="新增" OnClick="btnAdd_Click" CssClass="btn" />
                        <asp:Button ID="btnRecycle2" runat="server" Text="放入回收站" OnClientClick="return checkValues('确定放入回收站？');"
                            OnClick="ibtnRemove_Click" CssClass="btn" />
                        <asp:Button ID="btnDelete2" runat="server" Text="永久删除" OnClientClick="return checkValues('确定永久删除？');"
                            OnClick="ibtnDelete_Click" CssClass="btn" />
                        <input type="button" id="btnAssign2" runat="server" value="分配" onclick="return assignCustomer();"
                            class="btn" />
                    </asp:View>
                    <asp:View ID="Viewsubcus" runat="server">
                        <asp:Button ID="btnRecycle3" runat="server" Text="放入回收站" OnClientClick="return checkValues('确定放入回收站？');"
                            OnClick="ibtnRemove_Click" CssClass="btn" />
                        <asp:Button ID="btnShare3" runat="server" Text="共享" OnClientClick="return checkValues('确定要共享用户？');"
                            OnClick="ibtnShare_Click" CssClass="btn" />
                        <input type="button" id="btnAssign3" runat="server" value="分配" onclick="return assignCustomer();"
                            class="btn" />
                    </asp:View>
                    <asp:View ID="Viewrecyclecus" runat="server">
                        <asp:Button ID="btnBack4" runat="server" Text="恢复" OnClientClick="return checkValues('确定要恢复选中客户？');"
                            OnClick="ibtnBack_Click" CssClass="btn" />
                        <asp:Button ID="btnDelete4" runat="server" Text="永久删除" OnClientClick="return checkValues('确定永久删除？');"
                            OnClick="ibtnDelete_Click" CssClass="btn" />
                    </asp:View>
                </asp:MultiView>
            </div>
            <h4>
                客户列表
            </h4>
            <div id="right_bottom">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerId"
                    Width="100%" CssClass="gridview" AllowPaging="True" OnPageIndexChanging="gvlist_PageIndexChanging"
                    PageSize="20">
                    <PagerSettings Position="TopAndBottom" />
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <HeaderTemplate>
                                <input type="checkbox" id="ckall" name="ckall" onclick="checkall(this.checked)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="chkExport" runat="server" type="checkbox" value='<%# Eval("CustomerId").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户名称">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl='<%# "Customer.aspx?cid="+Eval("CustomerId")%>'
                                    Text='<%# Eval("Name") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户分类">
                            <ItemTemplate>
                                <%# GetCustomerTypeName(Eval("TypeId").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户行业">
                            <ItemTemplate>
                                <%# GetCustomerTradeName(Eval("TradeId").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%# GetCustomerStateName(Eval("StateId").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户来源">
                            <ItemTemplate>
                                <%# GetCustomerSourceName(Eval("SourceId").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="手机">
                            <ItemTemplate>
                                <%# Eval("MobilePhone")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="主页">
                            <ItemTemplate>
                                <a href='<%# Eval("HomePage") %>' target="_blank">
                                    <%# Eval("HomePage") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl='<%# "EditCustomer.aspx?cid="+Eval("CustomerId") %>'
                                    Text="修改" Visible='<%# this.HasPopedom("CustomerEdit") %>'></asp:HyperLink>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# SearchCustomer(Eval("Name").ToString())%>'
                                    Text="客户通" Target="_blank"></asp:HyperLink>
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
