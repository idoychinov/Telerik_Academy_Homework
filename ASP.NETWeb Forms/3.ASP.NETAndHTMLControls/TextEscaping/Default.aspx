<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TextEscaping.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label AssociatedControlID="InputTextBox" ID="InputLabel" runat="server">Enter text here: </asp:Label>
            <asp:TextBox ID="InputTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
            <br />
            <asp:Label AssociatedControlID="OutputTextBox" ID="OutputLabel" runat="server" >Output here: </asp:Label>
            <asp:TextBox ID="OutputTextBox" runat="server"></asp:TextBox>
            <br />
        </div>
    </form>
</body>
</html>
