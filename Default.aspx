<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ashland Soccer</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="auto-style1">
            <img  src="AshlandSoccer.jpg" alt="ashland soccer" style="height: 200px; width: 500px" /><br />
            <asp:Label ID="lblErrorMessage" runat="server" BorderStyle="None"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" height="19px" Text="Field" width="38px"></asp:Label>
            <asp:DropDownList ID="ddField" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="Team" height="19px" width="38px"></asp:Label>
            <asp:DropDownList ID="ddTeam" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" height="19px" Text="Status" width="40px"></asp:Label>
            <asp:DropDownList ID="ddStatus" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <%--<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="330px" />--%>
            <br />
            <asp:ListBox ID="lbField" runat="server" Visible="False"></asp:ListBox>
            <asp:ListBox ID="lbTeam" runat="server" Visible="False"></asp:ListBox>
            <asp:ListBox ID="lbStatus" runat="server" Visible="False"></asp:ListBox>
            <br />
            </div>
            <asp:GridView ID="gvDisplay" runat="server" style="text-align: center" HorizontalAlign="Center">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
