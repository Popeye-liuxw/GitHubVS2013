<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Area.ascx.cs" Inherits="EAPP.CRM.Web.Control.Area" %>

<script type="text/javascript" src="/JS/base.js"></script>

<script type="text/javascript" src="/JS/MyArea.js"></script>

<asp:Panel ID="d" runat="server"></asp:Panel>
<input id="result" name="result" type="hidden" runat = "server" />    

<script type="text/javascript">

    function GetDataTable(val)
    {
        return result = EAPP.CRM.Web.Control.Area.GetCityData(val).value;
    }    
    
    function GetData(val)
    {
        return result = EAPP.CRM.Web.Control.Area.GetCity(val).value;
    }    
       
    var xx = new MyArea($("<%= this.d.ClientID %>"),$("<%= this.result.ClientID %>"),'<%= this.CityId %>');
    xx.init();
</script>