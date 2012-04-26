<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Permission.ascx.cs"
    Inherits="Wysnan.EIMOnline.MVC.TestFile.Permission" %>
<asp:Button ID="Button1" runat="server" Text="btnModule" OnClick="Button1_Click" />
<asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
<asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
<asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label>
<asp:Button ID="Button2" runat="server" Text="btnMune"  Visible="false" 
    onclick="Button2_Click"/>
<asp:DataList ID="DataList1" runat="server">
</asp:DataList>
