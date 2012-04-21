<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Wysnan.EIMOnline.MVC.TestFile.Test" %>

<%@ Register Src="Permission.ascx" TagName="PermissionControl" TagPrefix="PermissionEntry" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <%--   <asp:GridView ID="GridView1" runat="server" Width="693px">
        </asp:GridView>--%>
        <PermissionEntry:PermissionControl ID="TestWebUserControl1" runat="server" />
    </div>
    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />--%>
    </form>
</body>
</html>
