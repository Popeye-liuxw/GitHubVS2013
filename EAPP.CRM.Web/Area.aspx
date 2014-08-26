<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Area.aspx.cs" Inherits="EAPP.CRM.Web.Area"
    MasterPageFile="~/MainTemplate.Master" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="contentPlaceHolderMain">

    <script type="text/javascript" src="js/build/yahoo-dom-event/yahoo-dom-event.js"></script>

    <script type="text/javascript" src="js/build/connection/connection-min.js"></script>

    <script type="text/javascript" src="js/build/treeview/treeview-min.js"></script>

    <script type="text/javascript" src="JS/base.js"></script>

    <link href="js/build/treeview/assets/skins/sam/treeview.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript"> 
             
            YAHOO.example.treeExample = function() {
                    var tree, currentIconMode;

                    function changeIconMode() {
                        var newVal = parseInt(this.value);
                        if (newVal != currentIconMode) {
                            currentIconMode = newVal;
                        }
                        buildTree();
                    }
                    
                    function loadNodeData(node, fnLoadComplete)  {
                        var aStates = EAPP.CRM.Web.Area.GetCityData(node.labelElId.toString()).value;
                        if(aStates.Rows.length > 0 ){
                            for (var i=0, j=aStates.Rows.length; i<j; i++) {                       
                                var tempNode = new YAHOO.widget.TextNode (aStates.Rows[i].AreaName, node, false);
                                tempNode.labelElId = aStates.Rows[i].AreaId;
                            }
                        }else{
                            node.isLeaf = true
                        }
                        fnLoadComplete();
                    }    
             
                    function buildTree() {
                       tree = new YAHOO.widget.TreeView("treeDiv1", currentIconMode);
                       
                       tree.setDynamicLoad(loadNodeData,currentIconMode);
                       var root = tree.getRoot();
                       var aStates = EAPP.CRM.Web.Area.GetCityData("0").value;
                                              
                       for (var i=0, j=aStates.Rows.length; i<j; i++) {                       
                            var tempNode = new YAHOO.widget.TextNode (aStates.Rows[i].AreaName, root, false);
                            tempNode.labelElId = aStates.Rows[i].AreaId;
                       }                       
                       tree.draw();
                       tree.subscribe('clickEvent',function(oArgs) {
                           YAHOO.util.Dom.get("<%= this.txtPid.ClientID %>").value = oArgs.node.labelElId.toString();
                           YAHOO.util.Dom.get("<%= this.txtPName.ClientID %>").value = oArgs.node.label;
                           YAHOO.util.Dom.get("<%= this.pid.ClientID %>").value = oArgs.node.labelElId.toString();
                           
                           YAHOO.util.Dom.get("fm").src = "PartArea.aspx?areaId=" + oArgs.node.labelElId;
		               });
                    }
             
               return {
                    init: function() {
                        YAHOO.util.Event.on(["mode0", "mode1"], "click", changeIconMode);
                        var el = document.getElementById("mode1");
                        if (el && el.checked) {
                            currentIconMode = parseInt(el.value);
                        } else {
                            currentIconMode = 0;
                        }

                        buildTree();
                    }

                }
            } ();
            YAHOO.util.Event.onDOMReady(YAHOO.example.treeExample.init, YAHOO.example.treeExample,true) 
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
                地区信息</h4>
            <div>
                <table style="width: 100%; border: 0px">
                    <tr>
                        <td style="width: 170px" valign="top" align="left">
                            <div id="treeDiv1" style="width: 170px;">
                            </div>
                        </td>
                        <td valign="top" align="left">
                            <div id="insert">
                                <table class="tinfo">
                                    <tr>
                                        <th style="width: 12%; min-width: 20px">
                                            <span style="display: none">
                                                <asp:TextBox ID="txtPid" runat="server" ReadOnly="true"></asp:TextBox>
                                            </span>
                                            <input id="pid" type="hidden" runat="server" />
                                            上级地区:
                                        </th>
                                        <td style="width: 20%;">
                                            <asp:TextBox ID="txtPName" ReadOnly="true" runat="server"></asp:TextBox>
                                        </td>
                                        <th style="width: 10%; min-width: 30px">
                                            地区名称:
                                        </th>
                                        <td style="width: 20%;">
                                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%; min-width: 30px">
                                            <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <iframe id="fm" src="PartArea.aspx?areaId=0" scrolling="no" frameborder="0" width="620px"
                                height="800px"></iframe>
                        </td>
                    </tr>
                </table>
                <div style="float: left; width: 600px">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
