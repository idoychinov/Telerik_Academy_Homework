<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RandomNumbers.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>With HTML Server controls</h2>
        <label for="FirstNumberHtmlControl">First Number</label>
        <input id="FirstNumberHtmlControl" type="text" runat="server"/>
        <br />
        <label for="SecondNumberHtmlControl">Second Number</label>
        <input id="SecondNumberHtmlControl" type="text" runat="server"/>
        <br />
        <label id="ResultHtmlControl" runat="server">Result</label>
        <br />
        <input id="ButtonSubmitHtmlControl" type="button"
      runat="server" value="Submit"
      onserverclick="ButtonSubmitHtmlControl_Click" />

    </div>

        <div>
        <h2>With Web Server controls</h2>
            <asp:Label AssociatedControlID="FirstNumberWebControl" ID="FirstNumberLabel" runat="server">First Number</asp:Label>
            <asp:TextBox ID="FirstNumberWebControl" runat="server"></asp:TextBox>
            <br />
            <asp:Label AssociatedControlID="SecondNumberWebControl" ID="SecondNumberLabel" runat="server">Second Number</asp:Label>
            <asp:TextBox ID="SecondNumberWebControl" runat="server"></asp:TextBox>
            <br />
            <asp:Literal ID="ResultWebControl" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="ButtonSubmitWebContrtol" runat="server" Text="Submit" OnClick="ButtonSubmitWebControl_Click"/>
    </div>
    </form>
</body>
</html>
